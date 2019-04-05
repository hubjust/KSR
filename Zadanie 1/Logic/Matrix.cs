using Logic.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Matrix
    {
        private readonly int CorrelationCoefficient; // współczynnik korelacji
        public Dictionary<string, List<double>> Weights = new Dictionary<string, List<double>>();
        private List<string> DistinctWords;
        private List<Article> Articles;
        public static IMetric CurrentMetric { get; set; }

        public double CountFrequency(Article article, string word)
        {
            int counter = 0;

            foreach(var w in article.Words)
            {
                if (w.Equals(word, StringComparison.CurrentCultureIgnoreCase))
                    counter++;
            }

            return counter;
            //  return article.Words.Count(s => s.Equals(word, StringComparison.CurrentCultureIgnoreCase));
        }

        public List<(Article Article, double Distance)> CountDistance(Article article) //Tuple trzeba zainstalować z NuGet
        {
            var articleIndex = Articles.IndexOf(article);
            var distances = new double[Articles.Count];

            for (int i = 0; i < Articles.Count; i++)
            {
                var firstVector = new List<double>();
                var secondVector = new List<double>();
                foreach (var distinctWord in DistinctWords)
                {
                    firstVector.Add(Weights[distinctWord][i]);
                    secondVector.Add(Weights[distinctWord][articleIndex]);
                }

                distances[i] = CurrentMetric.CountDistance(firstVector, secondVector);
            }

            return distances.Zip(Articles, (d, a) => (a, d)).ToList();
        }
    }
}
