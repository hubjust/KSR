using Logic.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class StaticVariable
    {
        #region Age
        public static LinguisticVariable ageYoung = new LinguisticVariable
        {
            Name = "Bardzo młody",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 17, 17, 18, 20 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 17, 17, 18, 20 }),
                FieldExtractor = (e) => e.Age

            }
        };
        public static LinguisticVariable ageYoungAdult = new LinguisticVariable
        {
            Name = "Młody",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 19, 21, 24, 29 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 19, 21, 24, 29 }),
                FieldExtractor = (e) => e.Age
            }
        };
        public static LinguisticVariable ageAdult = new LinguisticVariable
        {
            Name = "Dorosły",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 28, 30, 35, 37 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 28, 30, 35, 37 }),
                FieldExtractor = (e) => e.Age
            }
        };
        public static LinguisticVariable ageOld = new LinguisticVariable
        {
            Name = "Dojrzały",
            MemberToExtract = "Wiek",
            Extractor = e => new RectangularFunction(new List<double> { 36, 40, 45, 45 }).GetMembership(e.Age),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 36, 40, 45, 45 }),
                FieldExtractor = (e) => e.Age
            }
        };
        #endregion

        #region Height
        public static LinguisticVariable heightVeryShort = new LinguisticVariable
        {
            Name = "Bardzo Niski",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 155, 155, 160, 162 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 155, 155, 160, 162 }),
                FieldExtractor = (e) => e.Height

            }
        };
        public static LinguisticVariable heightShort = new LinguisticVariable
        {
            Name = "Niski",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 161, 165, 168, 170 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 161, 165, 168, 170 }),
                FieldExtractor = (e) => e.Height
            }
        };
        public static LinguisticVariable heightAverage = new LinguisticVariable
        {
            Name = "Przeciętny",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 169, 172, 176, 180 }).GetMembership(e.Heightge),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 169, 172, 176, 180 }),
                FieldExtractor = (e) => e.Height
            }
        };
        public static LinguisticVariable heightHigh = new LinguisticVariable
        {
            Name = "Wysoki",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 179, 182, 186, 192 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 179, 182, 186, 192 }),
                FieldExtractor = (e) => e.Height
            }
        };
        public static LinguisticVariable heightVeryHigh = new LinguisticVariable
        {
            Name = "Bardzo wysoki",
            MemberToExtract = "Wzrost",
            Extractor = e => new RectangularFunction(new List<double> { 191, 196, 205, 205 }).GetMembership(e.Height),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 191, 196, 205, 205 }),
                FieldExtractor = (e) => e.Height
            }
        };
        #endregion

        #region Weight
        public static LinguisticVariable weightLight = new LinguisticVariable
        {
            Name = "Niska",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 50, 55, 63, 68 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 50, 59, 66, 73 }),
                FieldExtractor = (e) => e.Weight

            }
        };
        public static LinguisticVariable weightNormal = new LinguisticVariable
        {
            Name = "Standardowa",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 72, 77, 79, 84 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 72, 77, 79, 84 }),
                FieldExtractor = (e) => e.Weight
            }
        };
        public static LinguisticVariable weightPortly = new LinguisticVariable
        {
            Name = "Postawna",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 83, 86, 89, 91 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 83, 86, 89, 91 }),
                FieldExtractor = (e) => e.Weight
            }
        };
        public static LinguisticVariable heightHeavy = new LinguisticVariable
        {
            Name = "Ciężka",
            MemberToExtract = "Waga",
            Extractor = e => new RectangularFunction(new List<double> { 90, 98, 110, 110 }).GetMembership(e.Weight),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 90, 98, 110, 110 }),
                FieldExtractor = (e) => e.Weight
            }
        };
        #endregion

        #region Pace
        public static LinguisticVariable paceLow = new LinguisticVariable
        {
            Name = "Niskie",
            MemberToExtract = "Tempo",
            Extractor = e => new RectangularFunction(new List<double> { 0, 15, 27, 35 }).GetMembership(e.Pace),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 0, 15, 27, 35 }),
                FieldExtractor = (e) => e.Pace

            }
        };
        public static LinguisticVariable paceAverage = new LinguisticVariable
        {
            Name = "Średnie",
            MemberToExtract = "Tempo",
            Extractor = e => new RectangularFunction(new List<double> { 33, 46, 58, 66 }).GetMembership(e.Pace),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 33, 46, 58, 66 }),
                FieldExtractor = (e) => e.Pace
            }
        };
        public static LinguisticVariable paceHigh = new LinguisticVariable
        {
            Name = "Wysokie",
            MemberToExtract = "Tempo",
            Extractor = e => new RectangularFunction(new List<double> { 65, 79, 88, 97 }).GetMembership(e.Pace),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 65, 79, 88, 97 }),
                FieldExtractor = (e) => e.Pace
            }
        };

        #endregion

        #region Acceleration
        public static LinguisticVariable accelerationBad = new LinguisticVariable
        {
            Name = "Słabe",
            MemberToExtract = "Przyspieszenie",
            Extractor = e => new RectangularFunction(new List<double> { 13, 25, 29, 35 }).GetMembership(e.Acceleration),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 13, 25, 29, 35 }),
                FieldExtractor = (e) => e.Acceleration

            }
        };
        public static LinguisticVariable accelerationNormal = new LinguisticVariable
        {
            Name = "Przeciętne",
            MemberToExtract = "Przyspieszenie",
            Extractor = e => new RectangularFunction(new List<double> { 33, 46, 58, 66 }).GetMembership(e.Acceleration),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 33, 46, 58, 66 }),
                FieldExtractor = (e) => e.Acceleration
            }
        };
        public static LinguisticVariable accelerationGood = new LinguisticVariable
        {
            Name = "Dobre",
            MemberToExtract = "Przyspieszenie",
            Extractor = e => new RectangularFunction(new List<double> { 65, 79, 88, 98 }).GetMembership(e.Acceleration),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 65, 79, 88, 98 }),
                FieldExtractor = (e) => e.Acceleration
            }
        };

        #endregion

        #region SprintSpeed
        public static LinguisticVariable sprintSpeedLow = new LinguisticVariable
        {
            Name = "Słaba",
            MemberToExtract = "Prędkość",
            Extractor = e => new RectangularFunction(new List<double> { 12, 25, 29, 37 }).GetMembership(e.SprintSpeed),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 12, 25, 29, 37 }),
                FieldExtractor = (e) => e.SprintSpeed

            }
        };
        public static LinguisticVariable sprintSpeedNormal = new LinguisticVariable
        {
            Name = "Przeciętna",
            MemberToExtract = "Prędkość",
            Extractor = e => new RectangularFunction(new List<double> { 36, 46, 58, 69 }).GetMembership(e.SprintSpeed),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 36, 46, 58, 69 }),
                FieldExtractor = (e) => e.SprintSpeed
            }
        };
        public static LinguisticVariable sprintSpeedHigh = new LinguisticVariable
        {
            Name = "Dobra",
            MemberToExtract = "Prędkość",
            Extractor = e => new RectangularFunction(new List<double> { 67, 79, 88, 97 }).GetMembership(e.SprintSpeed),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 67, 79, 88, 97 }),
                FieldExtractor = (e) => e.SprintSpeed
            }
        };

        #endregion

        #region Dribbling
        public static LinguisticVariable dribblingBad = new LinguisticVariable
        {
            Name = "Słaby",
            MemberToExtract = "Dribbling",
            Extractor = e => new RectangularFunction(new List<double> { 0, 15, 27, 37 }).GetMembership(e.Dribbling),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 0, 15, 27, 37 }),
                FieldExtractor = (e) => e.Dribbling

            }
        };
        public static LinguisticVariable dribblingNormal = new LinguisticVariable
        {
            Name = "Przeciętny",
            MemberToExtract = "Dribbling",
            Extractor = e => new RectangularFunction(new List<double> { 36, 46, 58, 69 }).GetMembership(e.Dribbling),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 36, 46, 58, 69 }),
                FieldExtractor = (e) => e.Dribbling
            }
        };
        public static LinguisticVariable dribblingGood = new LinguisticVariable
        {
            Name = "Dobry",
            MemberToExtract = "SprintSpeed",
            Extractor = e => new RectangularFunction(new List<double> { 67, 79, 88, 97 }).GetMembership(e.Dribbling),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 67, 79, 88, 97 }),
                FieldExtractor = (e) => e.Dribbling
            }
        };

        #endregion

        #region Agility
        public static LinguisticVariable agilityBad = new LinguisticVariable
        {
            Name = "Słaba",
            MemberToExtract = "Zręczność",
            Extractor = e => new RectangularFunction(new List<double> { 14, 21, 27, 37 }).GetMembership(e.Agility),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 14, 21, 27, 37 }),
                FieldExtractor = (e) => e.Agility

            }
        };
        public static LinguisticVariable agilityNormal = new LinguisticVariable
        {
            Name = "Przeciętna",
            MemberToExtract = "Zręczność",
            Extractor = e => new RectangularFunction(new List<double> { 36, 46, 58, 69 }).GetMembership(e.Agility),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 36, 46, 58, 69 }),
                FieldExtractor = (e) => e.Agility
            }
        };
        public static LinguisticVariable agilityGood = new LinguisticVariable
        {
            Name = "Dobra",
            MemberToExtract = "Zręczność",
            Extractor = e => new RectangularFunction(new List<double> { 67, 79, 88, 98 }).GetMembership(e.Agility),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 67, 79, 88, 98 }),
                FieldExtractor = (e) => e.Agility
            }
        };

        #endregion

        #region Balance
        public static LinguisticVariable balanceBad = new LinguisticVariable
        {
            Name = "Słaby",
            MemberToExtract = "Balans",
            Extractor = e => new RectangularFunction(new List<double> { 16, 21, 29, 40 }).GetMembership(e.Balance),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 16, 21, 29, 40 }),
                FieldExtractor = (e) => e.Balance

            }
        };
        public static LinguisticVariable balanceNormal = new LinguisticVariable
        {
            Name = "Przeciętny",
            MemberToExtract = "Balans",
            Extractor = e => new RectangularFunction(new List<double> { 38, 46, 58, 72 }).GetMembership(e.Balance),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 38, 46, 58, 72 }),
                FieldExtractor = (e) => e.Balance
            }
        };
        public static LinguisticVariable balanceGood = new LinguisticVariable
        {
            Name = "Dobry",
            MemberToExtract = "Balans",
            Extractor = e => new RectangularFunction(new List<double> { 71, 79, 88, 99 }).GetMembership(e.Balance),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 71, 79, 88, 99 }),
                FieldExtractor = (e) => e.Balance
            }
        };

        #endregion

        #region Reactions
        public static LinguisticVariable reactionsSlow = new LinguisticVariable
        {
            Name = "Wolne",
            MemberToExtract = "Reakcje",
            Extractor = e => new RectangularFunction(new List<double> { 30, 37, 43, 47 }).GetMembership(e.Reactions),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 30, 37, 43, 47 }),
                FieldExtractor = (e) => e.Reactions

            }
        };
        public static LinguisticVariable reactionsNormal = new LinguisticVariable
        {
            Name = "Przeciętne",
            MemberToExtract = "Reakcje",
            Extractor = e => new RectangularFunction(new List<double> { 46, 59, 66, 72 }).GetMembership(e.Reactions),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 46, 59, 66, 72 }),
                FieldExtractor = (e) => e.Reactions
            }
        };
        public static LinguisticVariable reactionsGood = new LinguisticVariable
        {
            Name = "Szybkie",
            MemberToExtract = "Reakcje",
            Extractor = e => new RectangularFunction(new List<double> { 71, 79, 88, 96 }).GetMembership(e.Reactions),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 71, 79, 88, 96 }),
                FieldExtractor = (e) => e.Reactions
            }
        };

        #endregion

        #region BallControl
        public static LinguisticVariable ballControlBad = new LinguisticVariable
        {
            Name = "Słaba",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 3, 14, 23, 26 }).GetMembership(e.BallControl),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 3, 14, 23, 26 }),
                FieldExtractor = (e) => e.BallControl

            }
        };
        public static LinguisticVariable ballControlNormal = new LinguisticVariable
        {
            Name = "Przeciętna",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 25, 39, 48, 57 }).GetMembership(e.BallControl),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 25, 39, 48, 57 }),
                FieldExtractor = (e) => e.BallControl
            }
        };
        public static LinguisticVariable ballControlGood = new LinguisticVariable
        {
            Name = "Dobra",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 56, 63, 69, 75 }).GetMembership(e.BallControl),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 56, 63, 69, 75 }),
                FieldExtractor = (e) => e.BallControl
            }
        };
        public static LinguisticVariable ballControlVeryGood = new LinguisticVariable
        {
            Name = "Bardzo dobra",
            MemberToExtract = "Kontrola piłki",
            Extractor = e => new RectangularFunction(new List<double> { 74, 81, 88, 99 }).GetMembership(e.BallControl),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 74, 81, 88, 99 }),
                FieldExtractor = (e) => e.BallControl
            }
        };

        #endregion

        #region Composure
        public static LinguisticVariable composureBad = new LinguisticVariable
        {
            Name = "Słabe",
            MemberToExtract = "Opanowanie",
            Extractor = e => new RectangularFunction(new List<double> { 3, 15, 24, 32 }).GetMembership(e.Composure),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 3, 15, 24, 32 }),
                FieldExtractor = (e) => e.Composure

            }
        };
        public static LinguisticVariable composureNormal = new LinguisticVariable
        {
            Name = "Zadowalające",
            MemberToExtract = "Opanowanie",
            Extractor = e => new RectangularFunction(new List<double> { 31, 44, 57, 66 }).GetMembership(e.Composure),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 31, 44, 57, 66 }),
                FieldExtractor = (e) => e.Composure
            }
        };
        public static LinguisticVariable composureGood = new LinguisticVariable
        {
            Name = "Bardzo dobre",
            MemberToExtract = "Opanowanie",
            Extractor = e => new RectangularFunction(new List<double> { 65, 75, 88, 97 }).GetMembership(e.Composure),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 65, 75, 88, 97 }),
                FieldExtractor = (e) => e.Composure
            }
        };

        #endregion

        #region Shooting
        public static LinguisticVariable shootingBad = new LinguisticVariable
        {
            Name = "Słaba",
            MemberToExtract = "Celność",
            Extractor = e => new RectangularFunction(new List<double> { 3, 15, 24, 32 }).GetMembership(e.Shooting),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 3, 15, 24, 32 }),
                FieldExtractor = (e) => e.Shooting

            }
        };
        public static LinguisticVariable shootingNormal = new LinguisticVariable
        {
            Name = "Przeciętna",
            MemberToExtract = "Celność",
            Extractor = e => new RectangularFunction(new List<double> { 31, 44, 57, 66 }).GetMembership(e.Shooting),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 31, 44, 57, 66 }),
                FieldExtractor = (e) => e.Shooting
            }
        };
        public static LinguisticVariable shootingGood = new LinguisticVariable
        {
            Name = "Dobra",
            MemberToExtract = "Celność",
            Extractor = e => new RectangularFunction(new List<double> { 65, 75, 88, 97 }).GetMembership(e.Shooting),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 65, 75, 88, 97 }),
                FieldExtractor = (e) => e.Shooting
            }
        };

        #endregion

        #region Positioning
        public static LinguisticVariable positioningBad = new LinguisticVariable
        {
            Name = "Słabe",
            MemberToExtract = "Ustawianie się",
            Extractor = e => new RectangularFunction(new List<double> { 3, 15, 24, 32 }).GetMembership(e.Positioning),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 3, 15, 24, 32 }),
                FieldExtractor = (e) => e.Positioning

            }
        };
        public static LinguisticVariable positioningNormal = new LinguisticVariable
        {
            Name = "Przeciętne",
            MemberToExtract = "Ustawianie się",
            Extractor = e => new RectangularFunction(new List<double> { 31, 44, 57, 66 }).GetMembership(e.Positioning),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 31, 44, 57, 66 }),
                FieldExtractor = (e) => e.Positioning
            }
        };
        public static LinguisticVariable positioningGood = new LinguisticVariable
        {
            Name = "Dobre",
            MemberToExtract = "Ustawianie się",
            Extractor = e => new RectangularFunction(new List<double> { 65, 75, 88, 97 }).GetMembership(e.Positioning),
            FuzzySet = new FuzzySet
            {
                MembershipFunction = new RectangularFunction(new List<double> { 65, 75, 88, 97 }),
                FieldExtractor = (e) => e.Positioning
            }
        };

        #endregion

        public static ObservableCollection<LinguisticVariable> getAllVariables()
        {
            return new ObservableCollection<LinguisticVariable>
            {
                
            };
        }
    }
}
