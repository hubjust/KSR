using System;
using System.Collections.Generic;
using System.Linq;

using Logic.Database;

namespace Logic
{
    public class Measures
    {
        // T1 - stopień prawdziwości
        public static double DegreeOfTruth(LinguisticVariable quantifier, LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double rUp = 0;
            double rDown = 0;

            foreach (FifaPlayer player in players)
            {
                rUp += Math.Min(qualifier.GetMembership(player), summarizer.GetMembership(player));
                rDown += qualifier.GetMembership(player);
            }

            if (quantifier.Absolute)
                return quantifier.GetMembership(rUp);
            else
                return quantifier.GetMembership(rUp / rDown);
        }

        // T2 - stopień nieprecyzyjności
        public static double DegreeOfImprecision(LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double quotient = 1;
            List<LinguisticVariable> AllLinguisticVariables = summarizer.GetAllLinguisticVariables();

            foreach (LinguisticVariable variable in AllLinguisticVariables)
                quotient *= variable.DegreeOfFuzziness(players);

            return 1 - Math.Pow(quotient, 1.0 / AllLinguisticVariables.Count);
        }

        // T3 - stopień pokrycia
        public static double DegreeOfCovering(LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double t = 0;
            double h = 0;

            foreach (var FifaPlayer in players)
            {
                if (qualifier.GetMembership(FifaPlayer) > 0)
                {
                    h++;

                    if (summarizer.GetMembership(FifaPlayer) > 0)
                        t++;
                }
            }

            return t / h;
        }

        // T4 - stopień trafności 
        public static double DegreeOfAppropriateness(LinguisticVariable qualifier, LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double quotient = 1;
            List<LinguisticVariable> AllLinguisticVariables = summarizer.GetAllLinguisticVariables();
            double t3 = DegreeOfCovering(qualifier, summarizer, players);

            foreach (LinguisticVariable variable in AllLinguisticVariables)
            {
                double sum = 0;

                foreach (FifaPlayer player in players)
                    sum += variable.GetMembership(player);

                quotient *= sum / players.Count() - t3;
            }

            return Math.Abs(quotient);
        }

        // T5 -  długość podsumowania
        public static double LengthOfSummary(LinguisticVariable summarizer)
        {
            int summarizers = summarizer.GetAllLinguisticVariables().Count;
            return 2 * Math.Pow(1.0 / 2.0, summarizers);
        }

        // T6 -  stopień nieprecyzyjności kwantyfikatora
        public static double DegreeOfQuantifierImprecision(LinguisticVariable quantifier, List<FifaPlayer> players)
        {
            double result = quantifier.MembershipFunction.Support();

            if (quantifier.Absolute)
                result /= (double)players.Count;

            return 1 - result;
        }

        // T7 - stopień liczności kwantyfikatora
        public static double DegreeOfQuantifierCardinality(LinguisticVariable quantifier, List<FifaPlayer> players)
        {
            double result = quantifier.MembershipFunction.Cardinality();

            if (quantifier.Absolute)
                result /= (double)players.Count;

            return 1 - result;
        }

        // T8 -  stopień liczności sumaryzatora
        public static double DegreeOfSummarizerCardinality(LinguisticVariable summarizer, List<FifaPlayer> players)
        {
            double quotient = 1;
            List<LinguisticVariable> AllLinguisticVariables = summarizer.GetAllLinguisticVariables();

            foreach (LinguisticVariable variable in AllLinguisticVariables)
                quotient *= variable.Cardinality() / players.Count;

            return 1 - Math.Pow(quotient, 1.0 / AllLinguisticVariables.Count);
        }

        // T9 - stopień nieprecyzyjności kwalifikatora
        public static double DegreeOfQualifierImprecision(LinguisticVariable qualifier, List<FifaPlayer> players)
        {
            return 1 - qualifier.DegreeOfFuzziness(players);
        }

        // T10 -  stopień liczności kwalifikatora
        public static double DegreeOfQualifierCardinality(LinguisticVariable qualifier, List<FifaPlayer> players)
        {
            return 1 - (qualifier.Cardinality() / players.Count);
        }

        // T11 - długość kwalifikatora
        public static double LengthOfQualifier(LinguisticVariable qualifier)
        {
            int qualifiers = qualifier.GetAllLinguisticVariables().Count;
            return 2 * Math.Pow(1.0 / 2.0, qualifiers);
        }
    }
}
