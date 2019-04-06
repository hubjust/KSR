using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Metrics
{
    public class Chebyshev
    {
        public static double Calculate(List<List<Article>> AllArticles, int k) //lista z danymi treningowymi i testowymi
        {
            List<Article> TrainingVectors = new List<Article>();
            List<Article> TestVectors = new List<Article>();
            double IsWordFounded = 0;

            //tworzy dane treningowe
            for (int i = 0; i < AllArticles.ElementAt(0).Count; i++)
            {
                TrainingVectors.Add(AllArticles.ElementAt(0).ElementAt(i));
            }

            //tworzy dane testowe
            for (int i = 0; i < AllArticles.ElementAt(1).Count; i++)
            {
                TestVectors.Add(AllArticles.ElementAt(1).ElementAt(i));
            }

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
