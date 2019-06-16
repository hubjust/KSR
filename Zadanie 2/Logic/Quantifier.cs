using Logic.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Quantifier
    {
        #region Quantizers
        //Względne
        public static LinguisticVariable no = new LinguisticVariable
        {
            QuantifierName = "Żaden",
            MembershipFunction = new TriangularFunction(0, 0, 0.1),
            Absolute = false
        };
        public static LinguisticVariable lessThanQuarter = new LinguisticVariable
        {
            QuantifierName = "Mniej niż ćwierć",
            MembershipFunction = new RectangularFunction(0, 0, 0.2, 0.25),
            Absolute = false
        };
        public static LinguisticVariable aroundOneThirds = new LinguisticVariable
        {
            QuantifierName = "Około jedna trzecia",
            MembershipFunction = new TriangularFunction(0.23, 0.33, 0.43),
            Absolute = false
        };
        public static LinguisticVariable aroundHalf = new LinguisticVariable
        {
            QuantifierName = "Około połowa",
            MembershipFunction = new TriangularFunction(0.4, 0.5, 0.6),
            Absolute = false
        };
        public static LinguisticVariable aroundTwoThirds = new LinguisticVariable
        {
            QuantifierName = "Około dwie trzecie",
            MembershipFunction = new TriangularFunction(0.56, 0.66, 0.76),
            Absolute = false
        };
        public static LinguisticVariable majority = new LinguisticVariable
        {
            QuantifierName = "Większość",
            MembershipFunction = new TriangularFunction(0.73, 0.83, 0.93),
            Absolute = false
        };
        public static LinguisticVariable almostAll = new LinguisticVariable
        {
            QuantifierName = "Prawie każdy",
            MembershipFunction = new TriangularFunction(0.85, 0.9, 1.05),
            Absolute = false
        };

        //Absolutne
        public static LinguisticVariable lessThan1000 = new LinguisticVariable
        {
            QuantifierName = "Mniej niż 1000",
            MembershipFunction = new RectangularFunction(0, 0, 990, 2000),
            Absolute = true
        };
        public static LinguisticVariable around4000 = new LinguisticVariable
        {
            QuantifierName = "Około 4000",
            MembershipFunction = new TriangularFunction(3000, 4000, 5000),
            Absolute = true
        };
        public static LinguisticVariable around9000 = new LinguisticVariable
        {
            QuantifierName = "Około 8000",
            MembershipFunction = new TriangularFunction(7000, 8000, 9000),
            Absolute = true
        };
        public static LinguisticVariable moreThan10000 = new LinguisticVariable
        {
            QuantifierName = "Więcej niż 10000",
            MembershipFunction = new RectangularFunction(9000, 9990, 10000, 20000),
            Absolute = true
        };


        #endregion
        public static ObservableCollection<LinguisticVariable> getAllQuantifiers()
        {
            return new ObservableCollection<LinguisticVariable>
            {
                no,
                lessThanQuarter,
                aroundHalf,
                aroundTwoThirds,
                majority,
                almostAll,
                lessThan1000,
                around4000,
                around9000,
                moreThan10000
            };
        }
    }
}
