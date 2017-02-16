using System.Collections.Generic;
using System.Linq;

namespace Filter.LtiFilters
{
    /// <summary>
    ///     Represents a filter with a constant gain and no effects otherwise.
    /// </summary>
    public class ZeroFilter : FiniteFilter
    {
        public ZeroFilter(double samplerate) : base(samplerate)
        {
            this.Name = "Zero Filter";
        }

        /// <summary>
        ///     Returns true.
        /// </summary>
        protected override bool HasEffectOverride => true;

        public override IEnumerable<double> ProcessOverride(IEnumerable<double> signal)
        {
            return signal.Select(d => 0.0);
        }
    }
}