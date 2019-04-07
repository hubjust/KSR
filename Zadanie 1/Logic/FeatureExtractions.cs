using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class FeatureExtractions
    {
        //liczba wystąpień danego słowa w artykule / suma liczby wystąpień wszystkich słów w artykule
        public static void TermFrequency(Article article)
        {
            Dictionary<string, double> vectorFeature = new Dictionary<string, double>();
            int wordFrequency = 0;

            for (int i = 0; i < article.Text.Count; i++)
            {
                for (int j = 0; j < article.Text.Count; j++)
                {
                    if (article.Text.ElementAt(i) == article.Text.ElementAt(j))
                    {
                        wordFrequency++;
                    }
                }

                if (vectorFeature.ContainsKey(article.Text.ElementAt(i))) continue;
                if (article.Text.ElementAt(i).Equals("")) continue;
                vectorFeature.Add(article.Text.ElementAt(i), (double)wordFrequency / article.Text.Count);
                wordFrequency = 0;
            }
            article.VectorFeatures = vectorFeature;
        }

        // log(liczba dokumentów w korpusie / liczba dokumentów zawierających przynajmniej jedno wystąpienie danego słowa)
        public static void InverseDocumentFrequency(List<Article> articles)
        {
            List<Article> helperList = articles.ToList();
            articles.Clear();

            double howManyDocumentsContainkeyword = 0;

            for (int i = 0; i < helperList.Count; i++)
            {
                if (helperList.ElementAt(i).Places.Count != 1)
                {
                    continue;
                }
                articles.Add(new Article { Places = helperList.ElementAt(i).Places, Text = helperList.ElementAt(i).Text });
                TermFrequency(articles.Last());
            }

            foreach (Article a in articles)
            {
                a.VectorFeatures = a.VectorFeatures.OrderBy(x => x.Value)
                    .Take(10)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            for (int i = 0; i < articles.Count; ++i)
            {
                for (int j = 0; j < articles[i].VectorFeatures.Count; ++j)
                {
                    foreach (Article a in articles)
                    {
                        if (a.Text.Contains(articles[i].VectorFeatures.Keys.ElementAt(j)))
                        {
                            howManyDocumentsContainkeyword++;
                        }
                    }
                    double tempDiff = (double)articles.Count / howManyDocumentsContainkeyword;
                    articles[i].VectorFeatures[articles[i].VectorFeatures.Keys.ElementAt(j)] = Math.Log10(tempDiff);
                    howManyDocumentsContainkeyword = 0;
                }
            }
        }

    }
}
