using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Metrics
{
    public class Manhattan : Metric
    {
        public override bool CalculateMetricForOneTestSet(Article testArticle, List<Article> TrainingVectors, int k, string tag)
        {
            double x = 0;
            double y = 0;
            double absResult = 0;


            for (int i = 0; i < TrainingVectors.Count; i++) //wykonujemy petle dla kazdego wzorca treningowego
            {
                foreach (var word in testArticle.VectorFeatures) //sprawdzamy dla kazdego slowa z wektora testowego czy istnieje takie slowo w wektorze treningowym
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
                    absResult += Math.Abs(x - y);
                }
                TrainingVectors.ElementAt(i).Distance = Math.Sqrt(absResult); //tu zapisujemy informacje o odległości ulicznej
                absResult = 0;
            }

            return KnnAlgorithm.Calculate(testArticle, TrainingVectors, k, tag);
        }
    }
}
