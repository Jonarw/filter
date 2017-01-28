﻿using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Filter.Algorithms.FFTWSharp;

namespace Filter_Win
{
    /// <summary>
    ///     Handles the creating of an fftw plan and the associated memory blocks.
    /// </summary>
    public class ComplexFftPlan
    {
        /// <summary>
        ///     Initializes a new instance of the base class <see cref="ComplexFftPlan" />.
        /// </summary>
        /// <param name="fftLength">The FFT lenght the plan is used for.</param>
        /// <param name="direction">The FFT direction.</param>
        public ComplexFftPlan(int fftLength, fftw_direction direction)
        {
            this.N = fftLength; 
            this.FftwIn = new fftw_complexarray(this.N);
            this.FftwOut = new fftw_complexarray(this.N);
            this.FftwP = fftw_plan.dft_1d(this.N, this.FftwIn, this.FftwOut, direction, fftw_flags.Measure);
        }

        /// <summary>
        ///     The FFT length the plan is used for.
        /// </summary>
        public int N { get; }

        /// <summary>
        ///     The FFTW plan.
        /// </summary>
        protected fftw_plan FftwP { get; set; }

        /// <summary>
        ///     The unmanaged data array for the real values.
        /// </summary>
        protected fftw_complexarray FftwIn { get; set; }

        /// <summary>
        ///     The unmanaged data array for the complex values.
        /// </summary>
        protected fftw_complexarray FftwOut { get; set; }

        /// <summary>
        ///     Executes the plan for the provided data.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>The (I)FFT of the input data.</returns>
        public IReadOnlyList<Complex> Execute(IEnumerable<Complex> input)
        {
            this.FftwIn.SetData(input.ToArray());
            this.FftwP.Execute();
            return this.FftwOut.GetData();
        }

    }
}