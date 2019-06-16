using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MembershipFunctions
{
    public class TriangularFunction : IMembershipFunction
    {
        private readonly double a, b, c;

        public TriangularFunction(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetMembership(double x)
        {
            if (x < a)
                return 0.0;
            else if (a <= x && x < b)
                return (x - a) / (b - a);
            else if (b == x)
                return 1.0;
            else if (b < x && x <= c)
                return (c - x) / (c - b);
            else
                return 0.0;
        }

        public List<IMembershipFunction> GetAllFunctions()
        {
            return new List<IMembershipFunction> { this };
        }

        public double Cardinality()
        {
            return (c - a) / 2;
        }

        public double Support()
        {
            return c - a;
        }
    }
}
