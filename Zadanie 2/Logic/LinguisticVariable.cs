using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Database;
using Logic.MembershipFunctions;

namespace Logic
{
    public class LinguisticVariable
    {
        public string Name { get; set; }
        public IMembershipFunction MembershipFunction { get; set; }
        public string MemberToExtract { get; set; }
        public Func<FifaPlayer, double> Extractor { get; set; }
        public bool Absolute { get; set; }
        public FuzzySet FuzzySet { get; set; }

        public double GetMemebership(FifaPlayer player)
        {
            return FuzzySet.GetMembership(player);
        }
        public string MemberAndName { get => MemberToExtract + ": " + Name; }
    }
}
