using System;

using Logic.Database;
using Logic.MembershipFunctions;

namespace Logic
{
    public class LinguisticVariable
    {
        public string Name { get; set; }
        public bool Absolute { get; set; }
        public string MemberToExtract { get; set; }
        public IMembershipFunction MembershipFunction { get; set; }
        public Func<FifaPlayer, double> Extractor { get; set; }
        public Func<FifaPlayer, double> FieldExtractor { get; set; }

        public double GetMemebership(FifaPlayer player)
        {
            return MembershipFunction.GetMembership(Extractor(player));
        }
        public string MemberAndName { get => MemberToExtract + ": " + Name; }

    }
}
