using Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class AndSummarizer : LinguisticVariable
    {
        public LinguisticVariable firstSummarizer;
        public LinguisticVariable secondSummarizer;

        public AndSummarizer(LinguisticVariable fSum, LinguisticVariable sSum)
        {
            firstSummarizer = fSum;
            secondSummarizer = sSum;
        }

        public override double GetMembership(FifaPlayer player)
        {
            return Math.Min(firstSummarizer.GetMembership(player), secondSummarizer.GetMembership(player));
        }

        public override double GetMembership(double value)
        {
            return Math.Min(firstSummarizer.GetMembership(value), secondSummarizer.GetMembership(value));
        }

        public override List<FifaPlayer> Support(List<FifaPlayer> players)
        {
            return firstSummarizer.Support(players).Intersect(secondSummarizer.Support(players)).ToList(); ;
        }

        public override double DegreeOfFuzziness(List<FifaPlayer> players)
        {
            return firstSummarizer.DegreeOfFuzziness(players) * secondSummarizer.DegreeOfFuzziness(players);
        }

        public override List<LinguisticVariable> GetAllLinguisticVariables()
        {
            return firstSummarizer.GetAllLinguisticVariables().Concat(secondSummarizer.GetAllLinguisticVariables()).ToList();
        }

        public override string ToString()
        {
            return " oraz ";
        }
    }
}
