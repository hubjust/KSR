using Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Measures
    {
        public static double WeightedMeasure(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            List<double> measureValues = new List<double>
            {
                (8.0 / 11) * DegreeOfTruth(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfImprecision(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfCovering(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfAppropriateness(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * LengthOfSummary(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfQuantifierImprecision(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfQuantifierCardinality(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfSummarizerCardinality(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfQualifierImprecision(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * DegreeOfQualifierCardinality(quantificator, qualifier, summarizer, players),
                (3.0 / 110) * LengthOfQualifier(quantificator, qualifier, summarizer, players)
            };

            return measureValues.Sum();
        }

        //T1
        public static double DegreeOfTruth(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double up = 0;
            double down = 0;
            foreach (FifaPlayer e in players)
            {
                up += Math.Min(qualifier.GetMembership(e), summarizer.GetMembership(e));
                down += qualifier.Extractor(e);
            }
            if (quantificator.Absolute)
                return quantificator.MembershipFunction.GetMembership(up);
            return quantificator.MembershipFunction.GetMembership(up / down);
        }

        //T2
        public static double DegreeOfImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double ret = 1;
            var lingVariables = summarizer.GetAllLinguisticVariables();
            foreach (var set in lingVariables)
            {
                ret *= set.DegreeOfFuzziness(players);
            }
            ret = Math.Pow(ret, 1 / lingVariables.Count);
            return 1 - ret;
        }

        //T3
        public static double DegreeOfCovering(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double up = 0;
            double down = 0;

            foreach (var FifaPlayer in players)
            {
                var qualVal = qualifier.GetMembership(FifaPlayer);
                var sumVal = summarizer.GetMembership(FifaPlayer);
                if (qualVal > 0)
                {
                    down++;
                    if (sumVal > 0)
                    {
                        up++;
                    }
                }
            }

            return up / down;
        }

        //T4
        public static double DegreeOfAppropriateness(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double ret = 0;
            var sets = summarizer.GetAllLinguisticVariables();
            double t3 = DegreeOfCovering(quantificator, qualifier, summarizer, players);
            foreach (var set in sets)
            {
                ret += (set.Support(players).Count() / players.Count()) - t3;
            }
            return Math.Abs(ret);
        }

        //T5
        public static double LengthOfSummary(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            var nOfSummarizers = summarizer.GetAllLinguisticVariables().Count;
            return 2 * Math.Pow(1.0 / 2.0, nOfSummarizers);
        }

        //T6
        public static double DegreeOfQuantifierImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            var ret = (quantificator.MembershipFunction.Parameters.Last()
                       - quantificator.MembershipFunction.Parameters.First());

            if (quantificator.Absolute)
            {
                ret /= (double)players.Count;
            }
            return 1 - ret;
        }

        //T7
        public static double DegreeOfQuantifierCardinality(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double ret = quantificator.MembershipFunction.Cardinality();
            if (quantificator.Absolute)
            {
                ret /= (double)players.Count;
            }
            return 1 - ret;
        }

        //T8
        public static double DegreeOfSummarizerCardinality(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double ret = 1;
            var lingVariables = summarizer.GetAllLinguisticVariables();
            foreach (var set in lingVariables)
            {
                ret *= set.Cardinality() / players.Count;
            }
            ret = Math.Pow(ret, 1.0 / lingVariables.Count);
            return 1 - ret;
        }

        //T9
        public static double DegreeOfQualifierImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            return 1 - qualifier.DegreeOfFuzziness(players);
        }

        //T10
        public static double DegreeOfQualifierCardinality(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            return 1 - (qualifier.Cardinality() / players.Count);
        }

        //T11
        public static double LengthOfQualifier(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            var nOfSummarizers = qualifier.GetAllLinguisticVariables().Count;
            return 2 * Math.Pow(1.0 / 2.0, nOfSummarizers);
        }
    }
}
