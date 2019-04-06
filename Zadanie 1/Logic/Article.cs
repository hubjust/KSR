using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Article
    {
        public string Title { get; set; }
        public List<string> Text { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }
        public List<string> Places { get; set; } //tylko na chwilę w celach testowych, proszę nie usuwać

        // nie wiem co

        public Dictionary<string, double> VectorFeatures;
        public double Distance { get; set; }

        public static void GetExtract(Boolean isTermFrequency, List<Article> articles)
        {
            if (isTermFrequency)
            {
                foreach(Article a in articles)
                    FeatureExtractions.TermFrequency(a);
            }

            else
            {
                FeatureExtractions.InverseDocumentFrequency(articles);
            }

        }
    }
}
