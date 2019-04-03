using System;
using System.Collections.Generic;

namespace KSR.Metrics
{
    public class Euclidean : IMetric
    {
        public double CountDistance(List<double> x, List<double> y)
        {
            double distance = 0;

            for (int i = 0; i < x.Count; i++)
            {
                distance += Math.Pow(x[i] - y[i], 2);
            }

            return Math.Sqrt(distance);
        }
    }
}