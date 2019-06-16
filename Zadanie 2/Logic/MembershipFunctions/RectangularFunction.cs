using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MembershipFunctions
{
    public class RectangularFunction : IMembershipFunction
     {
        private readonly double a, b, c, d;

        public RectangularFunction(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double GetMembership(double x)
        {
            if (x < a)
                return 0.0;
            else if (a <= x && x < b)
                return (x - a) / (b - a);
            else if (b <= x && x <= c)
                return 1.0;
            else if (c < x && x <= d)
                return (d - x) / (d - c);
            else
                return 0.0;
        }

        public List<IMembershipFunction> GetAllFunctions()
        {
            return new List<IMembershipFunction> { this };
        }

        public double Cardinality()
        {
            return ((d - a) + (c - b)) / 2;
        }

        public double Support()
        {
            return d - a;
        }
    }
}
