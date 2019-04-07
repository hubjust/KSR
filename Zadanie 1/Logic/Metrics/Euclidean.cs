using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Metrics
{
    public class Euclidean
    {
        public static double Calculate(List<Article> TrainingVectors, List<Article> TestVectors, int k)
        {
            double IsWordFounded = 0;

            for (int i = 0; i < TestVectors.Count; i++)
            {
                if (CalculateEuclideanMetricForOneTestSet(TestVectors.ElementAt(i), TrainingVectors, k))
                {
                    IsWordFounded++;
                }
            }
            return IsWordFounded / TestVectors.Count;
        }

        public static bool CalculateEuclideanMetricForOneTestSet(Article testSet, List<Article> TrainingVectors, int k)
        {
            TestVectorAndTrainingVectors result = new TestVectorAndTrainingVectors();

            double x = 0;
            double y = 0;
            double powResult = 0;

            for (int i = 0; i < TrainingVectors.Count; i++) //wykonujemy petle dla kazdego wzorca treningowego
            {
                foreach (var word in testSet.VectorFeatures) //sprawdzamy dla kazdego slowa z wektora testowego czy istnieje takie slowo w wektorze treningowym
                {
                    if (TrainingVectors.ElementAt(i).VectorFeatures.ContainsKey(word.Key))
                    {
                        y = TrainingVectors.ElementAt(i).VectorFeatures[word.Key];
                    }
                    else
                    {
                        y = 0;
                    }

                    x = word.Value;
                    powResult += Math.Pow(x - y, 2); 
                }
                

                result.TestVector = testSet;
                TrainingVectors.ElementAt(i).Distance = Math.Sqrt(powResult); //tu zapisujemy informacje o odległości euklidesowej
                powResult = 0;
            }
            result.TrainingVectors = TrainingVectors;

            return KnnAlgorithm.Calculate(result, k);
        }
    }
}