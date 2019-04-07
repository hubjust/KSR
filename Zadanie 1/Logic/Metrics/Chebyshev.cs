using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Metrics
{
    public class Chebyshev : Metric
    {
        private bool CalculateMetricForOneTestSet(Article testSet, List<Article> TrainingVectors, int k)
        {
            TestVectorAndTrainingVectors result = new TestVectorAndTrainingVectors();

            double x = 0;
            double y = 0;
            double maxResult = 0;
            double distance = 0;

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

                    if (distance < Math.Abs(x - y))
                        distance = Math.Abs(x - y);
                    maxResult = distance;
                }

                result.TestVector = testSet;
                TrainingVectors.ElementAt(i).Distance = Math.Sqrt(maxResult); //tu zapisujemy informacje o odległości Czebyszewa
                maxResult = 0;
            }
            result.TrainingVectors = TrainingVectors;

            return KnnAlgorithm.Calculate(result, k);
        }
    }
}
