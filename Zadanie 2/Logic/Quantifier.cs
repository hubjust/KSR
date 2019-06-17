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
            MembershipFunction = new RectangularFunction(0, 0, 0.25, 0.35),
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
            MembershipFunction = new RectangularFunction(0.85, 0.9, 1, 1.05),
            Absolute = false
        };

        //Absolutne
        public static LinguisticVariable lessThan100 = new LinguisticVariable
        {
            QuantifierName = "Mniej niż 100",
            MembershipFunction = new RectangularFunction(0, 0, 99, 150),
            Absolute = true
        };
        public static LinguisticVariable around250 = new LinguisticVariable
        {
            QuantifierName = "Około 250",
            MembershipFunction = new TriangularFunction(150, 250, 350),
            Absolute = true
        };
        public static LinguisticVariable around500 = new LinguisticVariable
        {
            QuantifierName = "Około 500",
            MembershipFunction = new TriangularFunction(400, 500, 600),
            Absolute = true
        };
        public static LinguisticVariable around750 = new LinguisticVariable
        {
            QuantifierName = "Około 750",
            MembershipFunction = new TriangularFunction(650, 750, 850),
            Absolute = true
        };
        public static LinguisticVariable moreThan1000 = new LinguisticVariable
        {
            QuantifierName = "Więcej niż 1000",
            MembershipFunction = new RectangularFunction(950, 1000, 15397, 15397),
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
                around250,
                around500,
                around750,
                moreThan1000
            };
        }
    }
}
