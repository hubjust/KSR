using Logic.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Variable
    {
        #region Age
        public static LinguisticVariable ageYoung = new LinguisticVariable
        {
            QuantifierName = "Bardzo młody",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 17, 17, 18, 20 }).GetMembership(e.Age),
            MembershipFunction = new RectangularFunction(new List<double> { 17, 17, 18, 20 })
        };
        public static LinguisticVariable ageYoungAdult = new LinguisticVariable
        {
            QuantifierName = "Młody",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 19, 21, 24, 29 }).GetMembership(e.Age),
            MembershipFunction = new RectangularFunction(new List<double> { 19, 21, 24, 29 })
        };
        public static LinguisticVariable ageAdult = new LinguisticVariable
        {
            QuantifierName = "Dorosły",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 28, 30, 35, 37 }).GetMembership(e.Age),
            MembershipFunction = new RectangularFunction(new List<double> { 28, 30, 35, 37 })
        };
        public static LinguisticVariable ageOld = new LinguisticVariable
        {
            QuantifierName = "Dojrzały",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 36, 40, 45, 45 }).GetMembership(e.Age),
            MembershipFunction = new RectangularFunction(new List<double> { 36, 40, 45, 45 })
        };
        #endregion

        #region Height
        public static LinguisticVariable heightVeryShort = new LinguisticVariable
        {
            QuantifierName = "Bardzo Niski",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 155, 155, 160, 162 }).GetMembership(e.Height),
            MembershipFunction = new RectangularFunction(new List<double> { 155, 155, 160, 162 })
        };
        public static LinguisticVariable heightShort = new LinguisticVariable
        {
            QuantifierName = "Niski",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 161, 165, 168, 170 }).GetMembership(e.Height),
            MembershipFunction = new RectangularFunction(new List<double> { 161, 165, 168, 170 })
        };
        public static LinguisticVariable heightAverage = new LinguisticVariable
        {
            QuantifierName = "Przeciętny",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 169, 172, 176, 180 }).GetMembership(e.Height),
            MembershipFunction = new RectangularFunction(new List<double> { 169, 172, 176, 180 })
        };
        public static LinguisticVariable heightHigh = new LinguisticVariable
        {
            QuantifierName = "Wysoki",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 179, 182, 186, 192 }).GetMembership(e.Height),
            MembershipFunction = new RectangularFunction(new List<double> { 179, 182, 186, 192 })
        };
        public static LinguisticVariable heightVeryHigh = new LinguisticVariable
        {
            QuantifierName = "Bardzo wysoki",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 191, 196, 205, 205 }).GetMembership(e.Height),
            MembershipFunction = new RectangularFunction(new List<double> { 191, 196, 205, 205 })
        };
        #endregion

        #region Weight
        public static LinguisticVariable weightLight = new LinguisticVariable
        {
            QuantifierName = "Niska",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 50, 55, 63, 68 }).GetMembership(e.Weight),
            MembershipFunction = new RectangularFunction(new List<double> { 50, 59, 66, 73 })
        };
        public static LinguisticVariable weightNormal = new LinguisticVariable
        {
            QuantifierName = "Standardowa",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 72, 77, 79, 84 }).GetMembership(e.Weight),
            MembershipFunction = new RectangularFunction(new List<double> { 72, 77, 79, 84 })
        };
        public static LinguisticVariable weightPortly = new LinguisticVariable
        {
            QuantifierName = "Postawna",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 83, 86, 89, 91 }).GetMembership(e.Weight),
            MembershipFunction = new RectangularFunction(new List<double> { 83, 86, 89, 91 })
        };
        public static LinguisticVariable weightHeavy = new LinguisticVariable
        {
            QuantifierName = "Ciężka",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 90, 98, 110, 110 }).GetMembership(e.Weight),
            MembershipFunction = new RectangularFunction(new List<double> { 90, 98, 110, 110 })
        };
        #endregion

        #region Pace
        public static LinguisticVariable paceLow = new LinguisticVariable
        {
            QuantifierName = "Niskie",
            MemberToExtract = "Tempo",
            Extractor = e => new RectangularFunction(new List<double> { 0, 15, 27, 35 }).GetMembership(e.Pace),
            MembershipFunction = new RectangularFunction(new List<double> { 0, 15, 27, 35 })
        };
        public static LinguisticVariable paceAverage = new LinguisticVariable
        {
            QuantifierName = "Średnie",
            MemberToExtract = "Tempo",
            Extractor = e => new RectangularFunction(new List<double> { 33, 46, 58, 66 }).GetMembership(e.Pace),
            MembershipFunction = new RectangularFunction(new List<double> { 33, 46, 58, 66 })
        };
        public static LinguisticVariable paceHigh = new LinguisticVariable
        {
            QuantifierName = "Wysokie",
            MemberToExtract = "Tempo",
            Extractor = e => new RectangularFunction(new List<double> { 65, 79, 88, 97 }).GetMembership(e.Pace),
            MembershipFunction = new RectangularFunction(new List<double> { 65, 79, 88, 97 })
        };

        #endregion

        #region Acceleration
        public static LinguisticVariable accelerationBad = new LinguisticVariable
        {
            QuantifierName = "Słabe",
            MemberToExtract = "Przyspieszenie",
            Extractor = e => new RectangularFunction(new List<double> { 13, 25, 29, 35 }).GetMembership(e.Acceleration),
            MembershipFunction = new RectangularFunction(new List<double> { 13, 25, 29, 35 })
        };
        public static LinguisticVariable accelerationNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętne",
            MemberToExtract = "Przyspieszenie",
            Extractor = e => new RectangularFunction(new List<double> { 33, 46, 58, 66 }).GetMembership(e.Acceleration),
            MembershipFunction = new RectangularFunction(new List<double> { 33, 46, 58, 66 })
        };
        public static LinguisticVariable accelerationGood = new LinguisticVariable
        {
            QuantifierName = "Dobre",
            MemberToExtract = "Przyspieszenie",
            Extractor = e => new RectangularFunction(new List<double> { 65, 79, 88, 98 }).GetMembership(e.Acceleration),
            MembershipFunction = new RectangularFunction(new List<double> { 65, 79, 88, 98 })
        };

        #endregion

        #region SprintSpeed
        public static LinguisticVariable sprintSpeedLow = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Prędkość",
            Extractor = e => new RectangularFunction(new List<double> { 12, 25, 29, 37 }).GetMembership(e.SprintSpeed),
            MembershipFunction = new RectangularFunction(new List<double> { 12, 25, 29, 37 })
        };
        public static LinguisticVariable sprintSpeedNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Prędkość",
            Extractor = e => new RectangularFunction(new List<double> { 36, 46, 58, 69 }).GetMembership(e.SprintSpeed),
            MembershipFunction = new RectangularFunction(new List<double> { 36, 46, 58, 69 })
        };
        public static LinguisticVariable sprintSpeedHigh = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Prędkość",
            Extractor = e => new RectangularFunction(new List<double> { 67, 79, 88, 97 }).GetMembership(e.SprintSpeed),
            MembershipFunction = new RectangularFunction(new List<double> { 67, 79, 88, 97 })
        };

        #endregion

        #region Dribbling
        public static LinguisticVariable dribblingBad = new LinguisticVariable
        {
            QuantifierName = "Słaby",
            MemberToExtract = "Dribbling",
            Extractor = e => new RectangularFunction(new List<double> { 0, 15, 27, 37 }).GetMembership(e.Dribbling),
            MembershipFunction = new RectangularFunction(new List<double> { 0, 15, 27, 37 })
        };
        public static LinguisticVariable dribblingNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętny",
            MemberToExtract = "Dribbling",
            Extractor = e => new RectangularFunction(new List<double> { 36, 46, 58, 69 }).GetMembership(e.Dribbling),
            MembershipFunction = new RectangularFunction(new List<double> { 36, 46, 58, 69 })
        };
        public static LinguisticVariable dribblingGood = new LinguisticVariable
        {
            QuantifierName = "Dobry",
            MemberToExtract = "Dribbling",
            Extractor = e => new RectangularFunction(new List<double> { 67, 79, 88, 97 }).GetMembership(e.Dribbling),
            MembershipFunction = new RectangularFunction(new List<double> { 67, 79, 88, 97 })
        };

        #endregion

        #region Agility
        public static LinguisticVariable agilityBad = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Zręczność",
            Extractor = e => new RectangularFunction(new List<double> { 14, 21, 27, 37 }).GetMembership(e.Agility),
            MembershipFunction = new RectangularFunction(new List<double> { 14, 21, 27, 37 })
        };
        public static LinguisticVariable agilityNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Zręczność",
            Extractor = e => new RectangularFunction(new List<double> { 36, 46, 58, 69 }).GetMembership(e.Agility),
            MembershipFunction = new RectangularFunction(new List<double> { 36, 46, 58, 69 })
        };
        public static LinguisticVariable agilityGood = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Zręczność",
            Extractor = e => new RectangularFunction(new List<double> { 67, 79, 88, 98 }).GetMembership(e.Agility),
            MembershipFunction = new RectangularFunction(new List<double> { 67, 79, 88, 98 })
        };

        #endregion

        #region Balance
        public static LinguisticVariable balanceBad = new LinguisticVariable
        {
            QuantifierName = "Słaby",
            MemberToExtract = "Balans",
            Extractor = e => new RectangularFunction(new List<double> { 16, 21, 29, 40 }).GetMembership(e.Balance),
            MembershipFunction = new RectangularFunction(new List<double> { 16, 21, 29, 40 })
        };
        public static LinguisticVariable balanceNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętny",
            MemberToExtract = "Balans",
            Extractor = e => new RectangularFunction(new List<double> { 38, 46, 58, 72 }).GetMembership(e.Balance),
            MembershipFunction = new RectangularFunction(new List<double> { 38, 46, 58, 72 })
        };
        public static LinguisticVariable balanceGood = new LinguisticVariable
        {
            QuantifierName = "Dobry",
            MemberToExtract = "Balans",
            Extractor = e => new RectangularFunction(new List<double> { 71, 79, 88, 99 }).GetMembership(e.Balance),
            MembershipFunction = new RectangularFunction(new List<double> { 71, 79, 88, 99 })
        };

        #endregion

        #region Reactions
        public static LinguisticVariable reactionsSlow = new LinguisticVariable
        {
            QuantifierName = "Wolne",
            MemberToExtract = "Reakcje",
            Extractor = e => new RectangularFunction(new List<double> { 30, 37, 43, 47 }).GetMembership(e.Reactions),
            MembershipFunction = new RectangularFunction(new List<double> { 30, 37, 43, 47 })
        };
        public static LinguisticVariable reactionsNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętne",
            MemberToExtract = "Reakcje",
            Extractor = e => new RectangularFunction(new List<double> { 46, 59, 66, 72 }).GetMembership(e.Reactions),
            MembershipFunction = new RectangularFunction(new List<double> { 46, 59, 66, 72 })
        };
        public static LinguisticVariable reactionsGood = new LinguisticVariable
        {
            QuantifierName = "Szybkie",
            MemberToExtract = "Reakcje",
            Extractor = e => new RectangularFunction(new List<double> { 71, 79, 88, 96 }).GetMembership(e.Reactions),
            MembershipFunction = new RectangularFunction(new List<double> { 71, 79, 88, 96 })
        };

        #endregion

        #region BallControl
        public static LinguisticVariable ballControlBad = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 3, 14, 23, 26 }).GetMembership(e.BallControl),
            MembershipFunction = new RectangularFunction(new List<double> { 3, 14, 23, 26 })
        };
        public static LinguisticVariable ballControlNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 25, 39, 48, 57 }).GetMembership(e.BallControl),
            MembershipFunction = new RectangularFunction(new List<double> { 25, 39, 48, 57 })
        };
        public static LinguisticVariable ballControlGood = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 56, 63, 69, 75 }).GetMembership(e.BallControl),
            MembershipFunction = new RectangularFunction(new List<double> { 56, 63, 69, 75 })
        };
        public static LinguisticVariable ballControlVeryGood = new LinguisticVariable
        {
            QuantifierName = "Bardzo dobra",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 74, 81, 88, 99 }).GetMembership(e.BallControl),
            MembershipFunction = new RectangularFunction(new List<double> { 74, 81, 88, 99 })
        };

        #endregion

        #region Composure
        public static LinguisticVariable composureBad = new LinguisticVariable
        {
            QuantifierName = "Słabe",
            MemberToExtract = "Opanowanie",
            Extractor = e => new RectangularFunction(new List<double> { 3, 15, 24, 32 }).GetMembership(e.Composure),
            MembershipFunction = new RectangularFunction(new List<double> { 3, 15, 24, 32 })
        };
        public static LinguisticVariable composureNormal = new LinguisticVariable
        {
            QuantifierName = "Zadowalające",
            MemberToExtract = "Opanowanie",
            Extractor = e => new RectangularFunction(new List<double> { 31, 44, 57, 66 }).GetMembership(e.Composure),
            MembershipFunction = new RectangularFunction(new List<double> { 31, 44, 57, 66 })
        };
        public static LinguisticVariable composureGood = new LinguisticVariable
        {
            QuantifierName = "Bardzo dobre",
            MemberToExtract = "Opanowanie",
            Extractor = e => new RectangularFunction(new List<double> { 65, 75, 88, 97 }).GetMembership(e.Composure),
            MembershipFunction = new RectangularFunction(new List<double> { 65, 75, 88, 97 })
        };

        #endregion

        #region Shooting
        public static LinguisticVariable shootingBad = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Celność",
            Extractor = e => new RectangularFunction(new List<double> { 3, 15, 24, 32 }).GetMembership(e.Shooting),
            MembershipFunction = new RectangularFunction(new List<double> { 3, 15, 24, 32 })
        };
        public static LinguisticVariable shootingNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Celność",
            Extractor = e => new RectangularFunction(new List<double> { 31, 44, 57, 66 }).GetMembership(e.Shooting),
            MembershipFunction = new RectangularFunction(new List<double> { 31, 44, 57, 66 })
        };
        public static LinguisticVariable shootingGood = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Celność",
            Extractor = e => new RectangularFunction(new List<double> { 65, 75, 88, 97 }).GetMembership(e.Shooting),
            MembershipFunction = new RectangularFunction(new List<double> { 65, 75, 88, 97 })
        };

        #endregion

        #region Positioning
        public static LinguisticVariable positioningBad = new LinguisticVariable
        {
            QuantifierName = "Słabe",
            MemberToExtract = "Ustawianie się",
            Extractor = e => new RectangularFunction(new List<double> { 3, 15, 24, 32 }).GetMembership(e.Positioning),
            MembershipFunction = new RectangularFunction(new List<double> { 3, 15, 24, 32 })
        };
        public static LinguisticVariable positioningNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętne",
            MemberToExtract = "Ustawianie się",
            Extractor = e => new RectangularFunction(new List<double> { 31, 44, 57, 66 }).GetMembership(e.Positioning),
            MembershipFunction = new RectangularFunction(new List<double> { 31, 44, 57, 66 }),

        };
        public static LinguisticVariable positioningGood = new LinguisticVariable
        {
            QuantifierName = "Dobre",
            MemberToExtract = "Ustawianie się",
            Extractor = e => new RectangularFunction(new List<double> { 65, 75, 88, 97 }).GetMembership(e.Positioning),    
            MembershipFunction = new RectangularFunction(new List<double> { 65, 75, 88, 97 }),
            
        };

        #endregion

        public static ObservableCollection<LinguisticVariable> getAllVariables()
        {
            return new ObservableCollection<LinguisticVariable>
            {
            ageYoung, ageYoungAdult, ageAdult, ageOld,
            heightVeryShort, heightShort, heightAverage, heightHigh, heightVeryHigh,
            weightLight, weightNormal, weightPortly, weightHeavy,
            paceAverage, paceHigh, paceLow,
            accelerationBad, accelerationGood, accelerationNormal,
            sprintSpeedHigh, sprintSpeedLow, sprintSpeedNormal,
            dribblingBad, dribblingGood, dribblingNormal,
            agilityBad, agilityGood, agilityNormal,
            balanceBad, balanceGood, balanceNormal,
            reactionsGood, reactionsNormal, reactionsSlow,
            ballControlBad, ballControlGood, ballControlNormal, ballControlVeryGood,
            composureBad, composureGood, composureNormal,
            shootingBad, shootingGood, shootingNormal,
            positioningBad, positioningGood, positioningNormal
            };
        }
    }
}
