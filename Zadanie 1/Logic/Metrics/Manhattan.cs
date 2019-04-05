using System;
using System.Collections.Generic;

namespace Logic.Metrics
{
    public class Manhattan : IMetric
    {
        public double CountDistance(List<double> x, List<double> y)
        {
            double distance = 0;

            for (int i = 0; i < x.Count; i++)
            {
                distance += Math.Abs(x[i] - y[i]);
            }

            return distance;
        }
    }
}
