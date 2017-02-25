using System;
using System.Collections.Generic;
using System.Numerics;

namespace Filter.Algorithms
{
    /// <summary>
    ///     Plan for a real-valued IFFT.
    /// </summary>
    public class InverseRealFftPlan : RealFftPlan
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InverseRealFftPlan" /> class.
        /// </summary>
        /// <param name="fftLength">The FFT length the plan is used for.</param>
        public InverseRealFftPlan(int fftLength) : base(fftLength, FftwInterop.dft_c2r_1d)
        {
            this.NormalizationFactor = 1D / fftLength;
        }

        private double NormalizationFactor { get; }

        private static Dictionary<int, InverseRealFftPlan> PlanCache { get; } = new Dictionary<int, InverseRealFftPlan>();

        public void Execute(Complex[] input, double[] output)
        {
            if (input.Length != this.SpectrumLength)
                throw new ArgumentException();

            if (output.Length < this.FftLength)
                throw new ArgumentException();

            IntPtr pInput = IntPtr.Zero;
            IntPtr pOutput = IntPtr.Zero;

            try
            {
                pInput = FftwInterop.malloc(this.SpectrumLength * 2 * sizeof(double));
                pOutput = FftwInterop.malloc(this.FftLength * sizeof(double));

                unsafe
                {
                    fixed (Complex* pinputarray = input)
                    {
                        Interop.memcpy((void*)pInput, pinputarray, this.SpectrumLength * 2 * sizeof(double));
                    }

                    FftwInterop.execute_dft_c2r(this.Plan, pInput, pOutput);

                    fixed (double* pRet = output)
                    {
                        var dpOutput = (double*)pOutput;

                        for (int i = 0; i < this.FftLength; i++)
                        {
                            *(pRet + i) = *(dpOutput + i) * this.NormalizationFactor;
                        }
                    }
                }
            }
            finally
            {
                FftwInterop.free(pInput);
                FftwInterop.free(pOutput);
            }
        }

        public double[] Execute(Complex[] input)
        {
            var ret = new double[this.FftLength];
            this.Execute(input, ret);
            return ret;
        }

        public override unsafe void ExecuteUnsafe(IntPtr pInput, IntPtr pOutput)
        {
            FftwInterop.execute_dft_c2r(this.Plan, pInput, pOutput);
            var dpOutput = (double*)pOutput;

            for (int i = 0; i < this.FftLength; i++)
            {
                *(dpOutput + i) *= this.NormalizationFactor;
            }
        }

        public static InverseRealFftPlan GetPlan(int length)
        {
            if (!PlanCache.ContainsKey(length))
                PlanCache.Add(length, new InverseRealFftPlan(length));

            return PlanCache[length];
        }
    }
}