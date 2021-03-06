﻿using System.Collections.Generic;
using Filter.Algorithms;

namespace Filter.LtiFilters
{
    /// <summary>
    ///     Base class for all filters that can be described by their impulse response.
    /// </summary>
    /// <seealso cref="FilterBase" />
    public abstract class Convolver : FilterBase
    {
        protected Convolver(double samplerate) : base(samplerate)
        {
            this.Name = "convolver";
        }

        public abstract IReadOnlyList<double> ImpulseResponse { get; }

        protected override bool HasEffectOverride
        {
            get
            {
                if (this.ImpulseResponse == null)
                {
                    return false;
                }

                return true;
            }
        }

        public override IEnumerable<double> ProcessOverride(IEnumerable<double> signal)
        {
            return Dsp.Convolve(signal, this.ImpulseResponse);
        }
    }
}