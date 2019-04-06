﻿using System.Collections.Generic;

namespace Logic.Metrics
{
    public interface IMetric
    {
        double CountDistance(List<double> x, List<double> y);
    }
}