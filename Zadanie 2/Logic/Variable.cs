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
            StatExtractor = player => player.Age,
            MembershipFunction = new RectangularFunction(17, 17, 18, 20)
        };
        public static LinguisticVariable ageYoungAdult = new LinguisticVariable
        {
            QuantifierName = "Młody",
            MemberToExtract = "Wiek",
            StatExtractor = player => player.Age,
            MembershipFunction = new RectangularFunction(19, 21, 24, 29)
        };
        public static LinguisticVariable ageAdult = new LinguisticVariable
        {
            QuantifierName = "Dorosły",
            MemberToExtract = "Wiek",
            StatExtractor = player => player.Age,
            MembershipFunction = new RectangularFunction(28, 30, 35, 37)
        };
        public static LinguisticVariable ageOld = new LinguisticVariable
        {
            QuantifierName = "Dojrzały",
            MemberToExtract = "Wiek",
            StatExtractor = player => player.Age,
            MembershipFunction = new RectangularFunction(36, 40, 45, 45)
        };
        #endregion

        #region Height
        public static LinguisticVariable heightVeryShort = new LinguisticVariable
        {
            QuantifierName = "Bardzo Niski",
            MemberToExtract = "Wzrost",
            StatExtractor = player => player.Height,
            MembershipFunction = new RectangularFunction(155, 155, 160, 162)
        };
        public static LinguisticVariable heightShort = new LinguisticVariable
        {
            QuantifierName = "Niski",
            MemberToExtract = "Wzrost",
            StatExtractor = player => player.Height,
            MembershipFunction = new RectangularFunction(161, 165, 168, 170)
        };
        public static LinguisticVariable heightAverage = new LinguisticVariable
        {
            QuantifierName = "Przeciętny",
            MemberToExtract = "Wzrost",
            StatExtractor = player => player.Height,
            MembershipFunction = new RectangularFunction(169, 172, 176, 180)
        };
        public static LinguisticVariable heightHigh = new LinguisticVariable
        {
            QuantifierName = "Wysoki",
            MemberToExtract = "Wzrost",
            StatExtractor = player => player.Height,
            MembershipFunction = new RectangularFunction(179, 182, 186, 192)
        };
        public static LinguisticVariable heightVeryHigh = new LinguisticVariable
        {
            QuantifierName = "Bardzo wysoki",
            MemberToExtract = "Wzrost",
            StatExtractor = player => player.Height,
            MembershipFunction = new RectangularFunction(191, 196, 205, 205)
        };
        #endregion

        #region Weight
        public static LinguisticVariable weightLight = new LinguisticVariable
        {
            QuantifierName = "Niska",
            MemberToExtract = "Waga",
            StatExtractor = player => player.Weight,
            MembershipFunction = new RectangularFunction(50, 59, 66, 73)
        };
        public static LinguisticVariable weightNormal = new LinguisticVariable
        {
            QuantifierName = "Standardowa",
            MemberToExtract = "Waga",
            StatExtractor = player => player.Weight,
            MembershipFunction = new RectangularFunction(72, 77, 79, 84)
        };
        public static LinguisticVariable weightPortly = new LinguisticVariable
        {
            QuantifierName = "Postawna",
            MemberToExtract = "Waga",
            StatExtractor = player => player.Weight,
            MembershipFunction = new RectangularFunction(83, 86, 89, 91)
        };
        public static LinguisticVariable weightHeavy = new LinguisticVariable
        {
            QuantifierName = "Ciężka",
            MemberToExtract = "Waga",
            StatExtractor = player => player.Weight,
            MembershipFunction = new RectangularFunction(90, 98, 110, 110)
        };
        #endregion

        #region Pace
        public static LinguisticVariable paceLow = new LinguisticVariable
        {
            QuantifierName = "Niskie",
            MemberToExtract = "Tempo",
            StatExtractor = player => player.Pace,
            MembershipFunction = new RectangularFunction(0, 15, 27, 35)
        };
        public static LinguisticVariable paceAverage = new LinguisticVariable
        {
            QuantifierName = "Średnie",
            MemberToExtract = "Tempo",
            StatExtractor = player => player.Pace,
            MembershipFunction = new RectangularFunction(33, 46, 58, 66)
        };
        public static LinguisticVariable paceHigh = new LinguisticVariable
        {
            QuantifierName = "Wysokie",
            MemberToExtract = "Tempo",
            StatExtractor = player => player.Pace,
            MembershipFunction = new RectangularFunction(65, 79, 88, 97)
        };

        #endregion

        #region Acceleration
        public static LinguisticVariable accelerationBad = new LinguisticVariable
        {
            QuantifierName = "Słabe",
            MemberToExtract = "Przyspieszenie",
            StatExtractor = player => player.Acceleration,
            MembershipFunction = new RectangularFunction(13, 25, 29, 35)
        };
        public static LinguisticVariable accelerationNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętne",
            MemberToExtract = "Przyspieszenie",
            StatExtractor = player => player.Acceleration,
            MembershipFunction = new RectangularFunction(33, 46, 58, 66)
        };
        public static LinguisticVariable accelerationGood = new LinguisticVariable
        {
            QuantifierName = "Dobre",
            MemberToExtract = "Przyspieszenie",
            StatExtractor = player => player.Acceleration,
            MembershipFunction = new RectangularFunction(65, 79, 88, 98)
        };

        #endregion

        #region SprintSpeed
        public static LinguisticVariable sprintSpeedLow = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Prędkość",
            StatExtractor = player => player.SprintSpeed,
            MembershipFunction = new RectangularFunction(12, 25, 29, 37)
        };
        public static LinguisticVariable sprintSpeedNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Prędkość",
            StatExtractor = player => player.SprintSpeed,
            MembershipFunction = new RectangularFunction(36, 46, 58, 69)
        };
        public static LinguisticVariable sprintSpeedHigh = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Prędkość",
            StatExtractor = player => player.SprintSpeed,
            MembershipFunction = new RectangularFunction(67, 79, 88, 97)
        };

        #endregion

        #region Dribbling
        public static LinguisticVariable dribblingBad = new LinguisticVariable
        {
            QuantifierName = "Słaby",
            MemberToExtract = "Dribbling",
            StatExtractor = player => player.Dribbling,
            MembershipFunction = new RectangularFunction(0, 15, 27, 37)
        };
        public static LinguisticVariable dribblingNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętny",
            MemberToExtract = "Dribbling",
            StatExtractor = player => player.Dribbling,
            MembershipFunction = new RectangularFunction(36, 46, 58, 69)
        };
        public static LinguisticVariable dribblingGood = new LinguisticVariable
        {
            QuantifierName = "Dobry",
            MemberToExtract = "Dribbling",
            StatExtractor = player => player.Dribbling,
            MembershipFunction = new RectangularFunction(67, 79, 88, 97)
        };

        #endregion

        #region Agility
        public static LinguisticVariable agilityBad = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Zręczność",
            StatExtractor = player => player.Agility,
            MembershipFunction = new RectangularFunction(14, 21, 27, 37)
        };
        public static LinguisticVariable agilityNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Zręczność",
            StatExtractor = player => player.Agility,
            MembershipFunction = new RectangularFunction(36, 46, 58, 69)
        };
        public static LinguisticVariable agilityGood = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Zręczność",
            StatExtractor = player => player.Agility,
            MembershipFunction = new RectangularFunction(67, 79, 88, 98)
        };

        #endregion

        #region Balance
        public static LinguisticVariable balanceBad = new LinguisticVariable
        {
            QuantifierName = "Słaby",
            MemberToExtract = "Balans",
            StatExtractor = player => player.Balance,
            MembershipFunction = new RectangularFunction(16, 21, 29, 40)
        };
        public static LinguisticVariable balanceNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętny",
            MemberToExtract = "Balans",
            StatExtractor = player => player.Balance,
            MembershipFunction = new RectangularFunction(38, 46, 58, 72)
        };
        public static LinguisticVariable balanceGood = new LinguisticVariable
        {
            QuantifierName = "Dobry",
            MemberToExtract = "Balans",
            StatExtractor = player => player.Balance,
            MembershipFunction = new RectangularFunction(71, 79, 88, 99)
        };

        #endregion

        #region Reactions
        public static LinguisticVariable reactionsSlow = new LinguisticVariable
        {
            QuantifierName = "Wolne",
            MemberToExtract = "Reakcje",
            StatExtractor = player => player.Reactions,
            MembershipFunction = new RectangularFunction(30, 37, 43, 47)
        };
        public static LinguisticVariable reactionsNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętne",
            MemberToExtract = "Reakcje",
            StatExtractor = player => player.Reactions,
            MembershipFunction = new RectangularFunction(46, 59, 66, 72)
        };
        public static LinguisticVariable reactionsGood = new LinguisticVariable
        {
            QuantifierName = "Szybkie",
            MemberToExtract = "Reakcje",
            StatExtractor = player => player.Reactions,
            MembershipFunction = new RectangularFunction(71, 79, 88, 96)
        };

        #endregion

        #region BallControl
        public static LinguisticVariable ballControlBad = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Kontrola piłki",
            StatExtractor = player => player.BallControl,
            MembershipFunction = new RectangularFunction(3, 14, 23, 26)
        };
        public static LinguisticVariable ballControlNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Kontrola piłki",
            StatExtractor = player => player.BallControl,
            MembershipFunction = new RectangularFunction(25, 39, 48, 57)
        };
        public static LinguisticVariable ballControlGood = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Kontrola piłki",
            StatExtractor = player => player.BallControl,
            MembershipFunction = new RectangularFunction(56, 63, 69, 75)
        };
        public static LinguisticVariable ballControlVeryGood = new LinguisticVariable
        {
            QuantifierName = "Bardzo dobra",
            MemberToExtract = "Kontrola piłki",
            StatExtractor = player => player.BallControl,
            MembershipFunction = new RectangularFunction(74, 81, 88, 99)
        };

        #endregion

        #region Composure
        public static LinguisticVariable composureBad = new LinguisticVariable
        {
            QuantifierName = "Słabe",
            MemberToExtract = "Opanowanie",
            StatExtractor = player => player.Composure,
            MembershipFunction = new RectangularFunction(3, 15, 24, 32)
        };
        public static LinguisticVariable composureNormal = new LinguisticVariable
        {
            QuantifierName = "Zadowalające",
            MemberToExtract = "Opanowanie",
            StatExtractor = player => player.Composure,
            MembershipFunction = new RectangularFunction(31, 44, 57, 66)
        };
        public static LinguisticVariable composureGood = new LinguisticVariable
        {
            QuantifierName = "Bardzo dobre",
            MemberToExtract = "Opanowanie",
            StatExtractor = player => player.Composure,
            MembershipFunction = new RectangularFunction(65, 75, 88, 97)
        };

        #endregion

        #region Shooting
        public static LinguisticVariable shootingBad = new LinguisticVariable
        {
            QuantifierName = "Słaba",
            MemberToExtract = "Celność",
            StatExtractor = player => player.Shooting,
            MembershipFunction = new RectangularFunction(3, 15, 24, 32)
        };
        public static LinguisticVariable shootingNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętna",
            MemberToExtract = "Celność",
            StatExtractor = player => player.Shooting,
            MembershipFunction = new RectangularFunction(31, 44, 57, 66)
        };
        public static LinguisticVariable shootingGood = new LinguisticVariable
        {
            QuantifierName = "Dobra",
            MemberToExtract = "Celność",
            StatExtractor = player => player.Shooting,
            MembershipFunction = new RectangularFunction(65, 75, 88, 97)
        };

        #endregion

        #region Positioning
        public static LinguisticVariable positioningBad = new LinguisticVariable
        {
            QuantifierName = "Słabe",
            MemberToExtract = "Ustawianie się",
            StatExtractor = player => player.Positioning,
            MembershipFunction = new RectangularFunction(3, 15, 24, 32)
        };
        public static LinguisticVariable positioningNormal = new LinguisticVariable
        {
            QuantifierName = "Przeciętne",
            MemberToExtract = "Ustawianie się",
            StatExtractor = player => player.Positioning,
            MembershipFunction = new RectangularFunction(31, 44, 57, 66)
        };
        public static LinguisticVariable positioningGood = new LinguisticVariable
        {
            QuantifierName = "Dobre",
            MemberToExtract = "Ustawianie się",
            StatExtractor = player => player.Positioning,    
            MembershipFunction = new RectangularFunction(65, 75, 88, 97)
            
        };
        #endregion

        public static LinguisticVariable none = new LinguisticVariable
        {
            QuantifierName = "Każdy",
            MemberToExtract = "",
            StatExtractor = player => player.Age,
            MembershipFunction = new RectangularFunction(0, 1, 99, 100)
        };

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
            positioningBad, positioningGood, positioningNormal,
            none
            };
        }
    }
}
