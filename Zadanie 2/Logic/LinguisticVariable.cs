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

        private List<FifaPlayer> Support(List<FifaPlayer> players, IMembershipFunction function)
        {
            List<FifaPlayer> result = new List<FifaPlayer>();
            players.ForEach((e) => {
                if (function.GetMembership(StatExtractor(e)) > 0)
                {
                    result.Add(e);
                }
            });
            return result;
        }

        public virtual List<FifaPlayer> Support(List<FifaPlayer> players)
        {
            return Support(players, MembershipFunction);
        }

        private double DegreeOfFuzziness(List<FifaPlayer> players, IMembershipFunction function)
        {
            return (double)Support(players, function).Count / (double)players.Count;
        }

        public virtual double DegreeOfFuzziness(List<FifaPlayer> players)
        {
            return DegreeOfFuzziness(players, MembershipFunction);
        }

        public virtual List<double> DegreeOfFuzzinessForAllFunctions(List<FifaPlayer> players)
        {
            List<double> result = new List<double>();
            foreach (var func in MembershipFunction.GetAllFunctions())
            {
                result.Add(DegreeOfFuzziness(players, func));
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

        public virtual void SetAllLinguisticVariables(List<LinguisticVariable> sets)
        {

        }

        public override string ToString()
        {
            return QuantifierName + " " + MemberToExtract;
        }
    }
}
