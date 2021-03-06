﻿using System.Collections.Generic;
using System.Numerics;
using Filter.Series;

namespace Filter.Spectrum
{
    /// <summary>
    ///     Describes the spectrum of a digital signal.
    /// </summary>
    public interface ISpectrum
    {
        /// <summary>
        ///     Gets the frequencies where the spectrum is defined.
        /// </summary>
        ISeries Frequencies { get; }

        /// <summary>
        ///     Gets the group delay.
        /// </summary>
        IReadOnlyList<double> GroupDelay { get; }

        /// <summary>
        ///     Gets the magnitude.
        /// </summary>
        IReadOnlyList<double> Magnitude { get; }

        /// <summary>
        ///     Gets the phase.
        /// </summary>
        IReadOnlyList<double> Phase { get; }

        /// <summary>
        ///     Gets the complex values.
        /// </summary>
        IReadOnlyList<Complex> Values { get; }
    }
}