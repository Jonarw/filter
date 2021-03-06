using System;
using System.Collections.Generic;
using System.Linq;
using PropertyTools.DataAnnotations;

namespace Filter.LtiFilters
{
    /// <summary>
    ///     Represents a filter with a constant group delay and no effects otherwise.
    /// </summary>
    public class SampleDelayFilter : FilterBase
    {
        private double _delay;
        private int _SampleDelay;

        public SampleDelayFilter(double samplerate) : base(samplerate)
        {
            this.Name = "delay filter";
        }

        /// <summary>
        ///     True if <see cref="Delay" /> is not 0, false otherwise.
        /// </summary>
        protected override bool HasEffectOverride
        {
            get
            {
                if (this.SampleDelay == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public override IEnumerable<double> ProcessOverride(IEnumerable<double> signal)
        {
            return Enumerable.Repeat(0.0, this.SampleDelay).Concat(signal);
        }

        /// <summary>
        ///     Gets or sets the delay of the <see cref="SampleDelayFilter" /> in integer samples.
        /// </summary>
        [Category("delay")]
        [DisplayName("delay in samples")]
        public int SampleDelay
        {
            get { return Convert.ToInt32(this.Delay * this.Samplerate); }
            set
            {
                if (!this.SetField(ref this._SampleDelay, value))
                {
                    return;
                }

                this.Delay = value / this.Samplerate;
                this.OnChange();
            }
        }

        /// <summary>
        ///     Gets the delay of the <see cref="SampleDelayFilter" /> in seconds.
        /// </summary>
        [DisplayName("delay in seconds")]
        public double Delay
        {
            get { return this._delay; }
            private set { this.SetField(ref this._delay, value); }
        }
    }
}