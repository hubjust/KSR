using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MembershipFunctions
{
    public class RectangularFunction : IMembershipFunction
     {
        public List<double> Parameters
        {
            get => new List<double> { a, b, c, d };
            set
            {
                if (value.Count != 4)
                    throw new ArgumentException("Niepoprawna liczba argumentów funkcji trójkątnej");
                a = value[0];
                b = value[1];
                c = value[2];
                d = value[3];
            }
        }

        private double a, b, c, d;

        public RectangularFunction(List<double> parameters)
        {
            Parameters = parameters;
        }

        public double GetMembership(double x)
        {
            if (x <= a)
                return 0.0;
            else if (a <= x && x <= b)
                return (x - a) / (b - a);
            else if (b <= x && x <= c)
                return 1.0;
            else if (c <= x && x <= d)
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
    }
}
