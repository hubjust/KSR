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
            Name = "Żaden",
            MembershipFunction = new TriangularFunction(new List<double> { 0, 0, 0.1 }),
            Absolute = false
        };
        public static LinguisticVariable lessThanQuarter = new LinguisticVariable
        {
            Name = "Mniej niż ćwierć",
            MembershipFunction = new RectangularFunction(new List<double> { 0, 0, 0.2, 0.25 }),
            Absolute = false
        };
        public static LinguisticVariable aroundHalf = new LinguisticVariable
        {
            Name = "Około połowa",
            MembershipFunction = new TriangularFunction(new List<double> { 0.4, 0.5, 0.6 }),
            Absolute = false
        };
        public static LinguisticVariable aroundTwoThirds = new LinguisticVariable
        {
            Name = "Około trzy czwarte",
            MembershipFunction = new TriangularFunction(new List<double> { 0.6, 0.65, 0.7 }),
            Absolute = false
        };
        public static LinguisticVariable majority = new LinguisticVariable
        {
            Name = "Większość",
            MembershipFunction = new TriangularFunction(new List<double> { 0.75, 0.83, 0.9 }),
            Absolute = false
        };
        public static LinguisticVariable almostAll = new LinguisticVariable
        {
            Name = "Prawie każdy",
            MembershipFunction = new RectangularFunction(new List<double> { 0.85, 0.9, 1, 1 }),
            Absolute = false
        };

        //Absolutne
        public static LinguisticVariable lessThan1000 = new LinguisticVariable
        {
            Name = "Mniej niż tysiąc",
            MembershipFunction = new RectangularFunction(new List<double> { 0, 0, 990, 5000 }),
            Absolute = true
        };
        public static LinguisticVariable around4000 = new LinguisticVariable
        {
            Name = "Około 4000",
            MembershipFunction = new TriangularFunction(new List<double> { 3750, 4000, 4250 }),
            Absolute = true
        };
        public static LinguisticVariable around9000 = new LinguisticVariable
        {
            Name = "Około 9000",
            MembershipFunction = new TriangularFunction(new List<double> { 8750, 9000, 9250}),
            Absolute = true
        };
        public static LinguisticVariable around12000 = new LinguisticVariable
        {
            Name = "Około 12000",
            MembershipFunction = new TriangularFunction(new List<double> { 11750, 12000, 12250 }),
            Absolute = true
        };
        public static LinguisticVariable moreThan14000 = new LinguisticVariable
        {
            Name = "Więcej niż 14000",
            MembershipFunction = new RectangularFunction(new List<double> { 14000, 14500, 15000, 15000 }),
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
                around12000,
                moreThan14000
            };
        }
    }
}
