﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TrainingSets
    {
        public static List<List<Article>> SetTrainingAndTestSet(int PercentOfTrainingPatterns, List<Article> AllArticles)
        {
            double percent = (double)PercentOfTrainingPatterns / 100;
            int howManyTrainingPatterns = (int)(percent * AllArticles.Count);
            int howManyTestPatterns = AllArticles.Count - howManyTrainingPatterns;
            Sort(AllArticles);

            List<Article> TrainingPatterns = AllArticles.Take(howManyTrainingPatterns).ToList();
            List<Article> TestPatterns = AllArticles.Skip(howManyTrainingPatterns).Take(howManyTestPatterns).ToList();
            List<List<Article>> TrainingAndTestArticles = new List<List<Article>>
            {
                TrainingPatterns,
                TestPatterns
            };

            return TrainingAndTestArticles;
        }

        public static void Sort(List<Article> AllArticles)
        {
            foreach (Article a in AllArticles)
            {
                a.VectorFeatures = a.VectorFeatures.OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
}