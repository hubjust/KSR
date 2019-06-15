using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MembershipFunctions
{
    public interface IMembershipFunction
    {
        double GetMembership(double x);
        List<IMembershipFunction> GetAllFunctions();
        List<double> Parameters { get; set; }
        double Cardinality();
    }
}
