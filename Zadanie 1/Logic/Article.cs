using System;
using System.Collections.Generic;

namespace Logic
{
    public class Article
    {
        public string Title { get; set; }
        public List<string> Text { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }
        public List<string> SelectedTag { get; set; }
        public string AssignedTag { get; set; }

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
                FeatureExtractions.InverseDocumentFrequency(articles);
        }

        public override string ToString()
        {
            string result = Title;
            result += "\t\t\t\nTag: ";
            foreach(string s in SelectedTag)
            {
                result += s + " ";
            }
            result += "\t\t\t\nPrzypisany tag: " + AssignedTag;

            return result;
        }
    }
}
