using System.Collections.Generic;
using System.Linq;

namespace Logic.Metrics
{
    public abstract class Metric
    {
        public double Calculate(List<Article> TrainingVectors, List<Article> TestVectors, int k)
        {
            double WordsFound = 0;

            for (int i = 0; i < TestVectors.Count; i++)
            {
                if (CalculateMetricForOneTestSet(TestVectors.ElementAt(i), TrainingVectors, k))
                    WordsFound++;
            }

            return WordsFound / TestVectors.Count;
        }

        private bool CalculateMetricForOneTestSet(Article testSet, List<Article> TrainingVectors, int k)
        {
            return false;
        }
    }
}
