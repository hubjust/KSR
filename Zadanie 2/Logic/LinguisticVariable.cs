using System;
using System.Collections.Generic;
using Logic.Database;
using Logic.MembershipFunctions;

namespace Logic
{
    public class LinguisticVariable
    {
        public string QuantifierName { get; set; }
        public string MemberToExtract { get; set; }
        public bool Absolute { get; set; }
        public IMembershipFunction MembershipFunction { get; set; }
        public Func<FifaPlayer, double> StatExtractor { get; set; }

        public virtual double GetMembership(FifaPlayer player)
        {
            return MembershipFunction.GetMembership(StatExtractor(player));
        }

        public virtual double GetMembership(double value)
        {
            return MembershipFunction.GetMembership(value);
        }

        public virtual List<FifaPlayer> Support(List<FifaPlayer> players)
        {
            List<FifaPlayer> result = new List<FifaPlayer>();

            foreach(FifaPlayer player in players)
            {
                if (GetMembership(StatExtractor(player)) > 0)
                    result.Add(player);
            }

            return result;
        }

        public virtual double DegreeOfFuzziness(List<FifaPlayer> players)
        {
            return (double)Support(players).Count / (double)players.Count;
        }

        public virtual List<double> DegreeOfFuzzinessForAllFunctions(List<FifaPlayer> players)
        {
            List<double> result = new List<double>();
            foreach (var func in MembershipFunction.GetAllFunctions())
            {
                result.Add(DegreeOfFuzziness(players));
            }
            return result;
        }

        public virtual double Cardinality()
        {
            return MembershipFunction.Cardinality();
        }

        public virtual List<LinguisticVariable> GetAllLinguisticVariables()
        {
            return new List<LinguisticVariable> { this };
        }

        public override string ToString()
        {
            return QuantifierName + " " + MemberToExtract;
        }
    }
}
