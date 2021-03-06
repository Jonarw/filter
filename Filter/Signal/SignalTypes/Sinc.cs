using System;
using System.Numerics;
using Filter.Algorithms;
using Filter.Series;
using Filter.Spectrum;
using PropertyTools.DataAnnotations;

namespace Filter.Signal
{
    /// <summary>
    ///     Represents a Sinc (sin(pi*x) / (pi*x)) pulse.
    /// </summary>
    /// <seealso cref="Filter.Signal.SyntheticSignal" />
    public class Sinc : SyntheticSignal
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sinc" /> class.
        /// </summary>
        /// <param name="sampleRate">The sample rate.</param>
        /// <param name="frequency">The frequency.</param>
        /// <exception cref="System.Exception"></exception>
        public Sinc(double sampleRate, double frequency) : base(time => Dsp.Sinc(frequency * time / sampleRate), sampleRate)
        {
            this.Frequency = frequency;
            if ((frequency < 0) || (frequency > sampleRate / 2))
            {
                throw new Exception();
            }

            var frequencies = new CustomSeries(new[] {0, frequency, frequency, sampleRate / 2});
            this.Spectrum = new Spectrum.Spectrum(frequencies, new Complex[] {1 / (2 * frequency), 1 / (2 * frequency), 0, 0});
            this.DisplayName = "sinc, f = " + frequency;
        }

        /// <summary>
        ///     Gets the spectrum.
        /// </summary>
        public override ISpectrum Spectrum { get; }

        [Category("sinc")]
        [DisplayName("frequency")]
        public double Frequency { get; }
    }
}