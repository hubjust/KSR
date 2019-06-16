using Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class OrSummarizer : LinguisticVariable
    {
        public LinguisticVariable firstSummarizer;
        public LinguisticVariable secondSummarizer;

        public OrSummarizer(LinguisticVariable fSum, LinguisticVariable sSum)
        {
            firstSummarizer = fSum;
            secondSummarizer = sSum;
        }

        public override double GetMembership(FifaPlayer FifaPlayer)
        {
            return Math.Max(firstSummarizer.GetMembership(FifaPlayer), secondSummarizer.GetMembership(FifaPlayer));
        }

        public override List<FifaPlayer> Support(List<FifaPlayer> players)
        {
            return firstSummarizer.Support(players).Concat(secondSummarizer.Support(players)).Distinct().ToList();
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
            return " lub ";
        }
    }
}
