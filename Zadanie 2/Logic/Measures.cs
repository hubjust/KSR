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
        // T1 - stopień prawdziwości
        public static double DegreeOfTruth(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double result = 0;
            double rUp = 0;
            double rDown = 0;

            foreach (FifaPlayer player in players)
            {
                double a = qualifier.GetMembership(player);
                double b = summarizer.GetMembership(player);

                rUp += Math.Min(qualifier.GetMembership(player), summarizer.GetMembership(player));
                rDown += qualifier.GetMembership(player);
            }

            if (quantificator.Absolute)
                result = quantificator.GetMembership(rUp);
            else
                result = quantificator.GetMembership(rUp / rDown);

            return result;
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

        // T5 -  długość podsumowania
        public static double LengthOfSummary(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            int summarizers = summarizer.GetAllLinguisticVariables().Count;
            return 2 * Math.Pow(1.0 / 2.0, summarizers);
        }

        //T6
        public static double DegreeOfQuantifierImprecision(LinguisticVariable quantificator, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            //var ret = (quantificator.MembershipFunction.Parameters.Last()
            //           - quantificator.MembershipFunction.Parameters.First());

            //if (quantificator.Absolute)
            //{
            //    ret /= (double)players.Count;
            //}
            //return 1 - ret;
            return 0;
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
