using System.Collections.Generic;

namespace KSR.Metrics
{
    public interface IMetric
    {
        double CountDistance(List<double> x, List<double> y);
    }
}
