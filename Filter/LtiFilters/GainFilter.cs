using System.Collections.Generic;
using Filter.Extensions;
using PropertyTools.DataAnnotations;

namespace Filter.LtiFilters
{
    /// <summary>
    ///     Represents a filter with a constant gain and no effects otherwise.
    /// </summary>
    public class GainFilter : FilterBase
    {
        private double _Gain = 1;

        public GainFilter(double samplerate) : base(samplerate)
        {
            this.Name = "gain filter";
        }

        /// <summary>
        ///     True if <see cref="Gain" /> is not 1, false otherwise.
        /// </summary>
        protected override bool HasEffectOverride
        {
            get
            {
                if (this.Gain == 1)
                {
                    return false;
                }

                return true;
            }
        }

        public override IEnumerable<double> ProcessOverride(IEnumerable<double> signal)
        {
            return signal.Multiply(this.Gain);
        }

        /// <summary>
        ///     Gets or sets the linear gain factor of the <see cref="GainFilter" />.
        /// </summary>
        [Category("gain filter")]
        [DisplayName("gain")]
        public double Gain
        {
            get { return this._Gain; }
            set { this.SetField(ref this._Gain, value); }
        }
    }
}