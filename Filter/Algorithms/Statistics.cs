﻿using System;
using System.Collections.Generic;
using System.Linq;
using Filter.Extensions;

namespace Filter.Algorithms
{
    public static class Statistics
    {
        /// <summary>
        ///     Calculates the standard deviation of a sequence.
        /// </summary>
        /// <param name="values">The sequence.</param>
        /// <returns>The standard deviation of the sequence.</returns>
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var valueslist = values.ToReadOnlyList();
            return StandardDeviation(valueslist, valueslist.Average());
        }

        /// <summary>
        ///     Calculates the standard deviation of a sequence.
        /// </summary>
        /// <param name="values">The sequence.</param>
        /// <param name="mean">The mean of the sequence.</param>
        /// <returns>The standard deviation of the sequence.</returns>
        public static double StandardDeviation(this IEnumerable<double> values, double mean)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var valueslist = values.ToReadOnlyList();
            return Math.Sqrt(valueslist.Variance(mean));
        }

        /// <summary>
        ///     Calculates the variance of a sequence.
        /// </summary>
        /// <param name="values">The sequence.</param>
        /// <returns>The variance of the sequence.</returns>
        public static double Variance(this IEnumerable<double> values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var valueslist = values.ToReadOnlyList();
            return Variance(valueslist, valueslist.Average());
        }

        /// <summary>
        ///     Calculates the variance of a sequence.
        /// </summary>
        /// <param name="values">The sequence.</param>
        /// <param name="mean">The mean of the sequence.</param>
        /// <returns>The variance of the sequence.</returns>
        public static double Variance(this IEnumerable<double> values, double mean)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var valueslist = values.ToReadOnlyList();

            if (valueslist.Count == 0)
                return 0;

            double variance = valueslist.Aggregate(0.0, (d, d1) => d + Math.Pow(d1 - mean, 2));
            return variance / valueslist.Count;
        }
    }
}