﻿using System.Collections.Generic;
using System.Linq;

namespace Logic.Metrics
{
    public abstract class Metric
    {
        public double Calculate(List<Article> TrainingVectors, List<Article> TestVectors, int k, string tag)
        {
            double WordsFound = 0;

            for (int i = 0; i < TestVectors.Count; i++)
            {
                if (CalculateMetricForOneTestSet(TestVectors.ElementAt(i), TrainingVectors, k, tag))
                    WordsFound++;
            }

            return WordsFound / TestVectors.Count;
        }

        public abstract bool CalculateMetricForOneTestSet(Article testSet, List<Article> TrainingVectors, int k, string tag);
    }
}
