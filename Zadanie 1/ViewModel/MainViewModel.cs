using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KSR.Metrics;

namespace ViewModel
{
    public class MainViewModel
    {
        private IMetric metric;

        private readonly List<string> places = new List<string>
        {
            "west-germany",
            "usa",
            "france",
            "uk",
            "canada",
            "japan"
        };
    }
}
