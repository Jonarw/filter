﻿using Filter.Algorithms;
using Filter.Extensions;
using PropertyTools.DataAnnotations;

namespace Filter.Signal
{
    /// <summary>
    ///     Represents a logarithmic sine sweep.
    /// </summary>
    public class LogSweep : FiniteSignal
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sinc" /> Class.
        /// </summary>
        /// <param name="from">The start frequency.</param>
        /// <param name="to">The stop frequency.</param>
        /// <param name="length">The length in seconds.</param>
        /// <param name="samplerate">The samplerate.</param>
        public LogSweep(double from, double to, double length, double samplerate)
            : base(Dsp.LogSweep(from, to, length, samplerate).ToReadOnlyList(), samplerate)
        {
            this.From = @from;
            this.To = to;
            this.DisplayName = "logarithmic sweep";
        }

        [Category("logarithmic sweep")]
        [DisplayName("start frequency")]
        public double From { get; }

        [DisplayName("stop frequency")]
        public double To { get; }
    }
}