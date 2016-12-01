using Filter.Spectrum;

namespace Filter.Signal
{
    /// <summary>
    ///     Represents a digital signal representable in time domain with a known and analytically calculable spectrum.
    /// </summary>
    /// <seealso cref="Filter.Signal.InfiniteSignal" />
    /// <seealso cref="Filter.Signal.ISyntheticSignal" />
    public abstract class SyntheticSignal : InfiniteSignal, ISyntheticSignal
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SyntheticSignal" /> class.
        /// </summary>
        /// <param name="sampleFunction">The sample function.</param>
        /// <param name="sampleRate">The sample rate.</param>
        protected SyntheticSignal(TimeDomainFunc sampleFunction, double sampleRate) : base(sampleFunction, sampleRate)
        {
            this.DisplayName = "synthetic signal";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SyntheticSignal" /> class.
        /// </summary>
        /// <param name="timeDomainFunction">The time domain range function.</param>
        /// <param name="sampleRate">The sample rate.</param>
        protected SyntheticSignal(TimeDomainRangeFunc timeDomainFunction, double sampleRate) : base(timeDomainFunction, sampleRate)
        {
            this.DisplayName = "synthetic signal";
        }

        /// <summary>
        ///     Gets the spectrum.
        /// </summary>
        public abstract ISpectrum Spectrum { get; }
    }
}