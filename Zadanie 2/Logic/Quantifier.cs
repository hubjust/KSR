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
        public static LinguisticVariable lessThan100 = new LinguisticVariable
        {
            QuantifierName = "Mniej niż 100",
            MembershipFunction = new RectangularFunction(0, 0, 99, 200),
            Absolute = true
        };
        public static LinguisticVariable around400 = new LinguisticVariable
        {
            QuantifierName = "Około 400",
            MembershipFunction = new TriangularFunction(300, 400, 500),
            Absolute = true
        };
        public static LinguisticVariable around900 = new LinguisticVariable
        {
            QuantifierName = "Około 800",
            MembershipFunction = new TriangularFunction(700, 800, 900),
            Absolute = true
        };
        public static LinguisticVariable moreThan1000 = new LinguisticVariable
        {
            QuantifierName = "Więcej niż 1000",
            MembershipFunction = new RectangularFunction(900, 990, 15397, 15397),
            Absolute = true
        };
        #endregion

        public static ObservableCollection<LinguisticVariable> getAllQuantifiers()
        {
            return new ObservableCollection<LinguisticVariable>
            {
                no,
                lessThanQuarter,
                aroundOneThirds,
                aroundHalf,
                aroundTwoThirds,
                majority,
                almostAll,
                lessThan100,
                around400,
                around900,
                moreThan1000
            };
        }
    }
}
