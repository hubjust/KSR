using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Extractors
{
    public class FeatureExtractions
    {
        private bool UsingTermFrequency { get; set; }
        private bool UsingInverseDocumentFrequency { get; set; }
        private bool UsingOwnExtraction { get; set; }

        private bool UsingWordsCounter { get; set; }
        private bool UsingShortWordsCounter { get; set; }
        private bool UsingMediumWordsCounter { get; set; }
        private bool UsingLongWordsCounter { get; set; }
        private bool UsingUniqueWordsCounter { get; set; }
        private bool UsingFirstLetterUpperCase { get; set; }
        private bool UsingWordsUpperCase { get; set; }

        public void Extract(List<Article> articles)
        {
            if (UsingTermFrequency)
            {
                foreach (Article a in articles)
                    TermFrequency(a);
            }
            else if (UsingInverseDocumentFrequency)
                InverseDocumentFrequency(articles);

            else if (UsingOwnExtraction)
            {
                foreach (Article a in articles)
                    OwnExtraction(a);
            }  
        }

        private void TermFrequency(Article article)
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
        private void InverseDocumentFrequency(List<Article> articles)
        {
            List<Article> helperList = articles.ToList();
            articles.Clear();

            double howManyDocumentsContainkeyword = 0;

            for (int i = 0; i < helperList.Count; i++)
            {
                if (helperList.ElementAt(i).SelectedTag.Count != 1)
                {
                    continue;
                }
                articles.Add(new Article { SelectedTag = helperList.ElementAt(i).SelectedTag, Text = helperList.ElementAt(i).Text });
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

        private void OwnExtraction(Article article)
        {
            Dictionary<string, double> vectorFeature = new Dictionary<string, double>();

            if (UsingWordsCounter)
                vectorFeature.Add("WordsCounter", WordsCounterExtractor.ComputeFactor(article));

            if (UsingShortWordsCounter)
                vectorFeature.Add("ShortWordsCounter", ShortWordsCounterExtractor.ComputeFactor(article));

            if (UsingMediumWordsCounter)
                vectorFeature.Add("MediumWordsCounter", MediumWordsCountExtractor.ComputeFactor(article));

            if (UsingLongWordsCounter)
                vectorFeature.Add("LongWordsCounter", LongWordsCounterExtractor.ComputeFactor(article));

            if (UsingUniqueWordsCounter)
                vectorFeature.Add("UniqueWordsCounter", UniqueWordsCounterExtractor.ComputeFactor(article));

            if (UsingWordsUpperCase)
                vectorFeature.Add("UpperCaseWordsCounter", WordsUpperCaseCounterExtractor.ComputeFactor(article));

            if (UsingFirstLetterUpperCase)
                vectorFeature.Add("FirstLetterUperCaseCounter", FirstLetterUpperCaseCounterExtractor.ComputeFactor(article));

            article.VectorFeatures = vectorFeature;
        }

        public void SetBools(bool usingTermFrequency, bool usingInverseDocumentFrequency, bool usingOwnExtraction,
                             bool usingWordsCounter, bool usingShortWordsCounter, bool usingMediumWordsCounter, 
                             bool usingLongWordsCounter, bool usingUniqueWordsCounter, bool usingFirstLitterUpperCase, bool usingWordsUpperCase)
        {
            UsingTermFrequency = usingTermFrequency;
            UsingInverseDocumentFrequency = usingInverseDocumentFrequency;
            UsingOwnExtraction = usingOwnExtraction;
            UsingWordsCounter = usingWordsCounter;
            UsingShortWordsCounter = usingShortWordsCounter;
            UsingMediumWordsCounter = usingMediumWordsCounter;
            UsingLongWordsCounter = usingLongWordsCounter;
            UsingUniqueWordsCounter = usingUniqueWordsCounter;
            UsingFirstLetterUpperCase = usingFirstLitterUpperCase;
            UsingWordsUpperCase = usingWordsUpperCase;
        }
    }
}
