using Filter.Spectrum;

namespace Filter.Signal
{
    /// <summary>
    ///     Describes a digital signal representable in time domain with a known and analytically calculable spectrum.
    /// </summary>
    public interface ISyntheticSignal : ISignal
    {
        /// <summary>
        ///     Gets the spectrum.
        /// </summary>
        ISpectrum Spectrum { get; }
    }
}