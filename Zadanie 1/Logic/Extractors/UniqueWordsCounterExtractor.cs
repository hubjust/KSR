using System;
using System.Collections.Generic;

namespace Logic.Extractors
{
    class UniqueWordsCounterExtractor : IExtractor
    {
        public double ComputeFactor(Article article)
        {
            List<string> uniqueWords = new List<string>();

            foreach(string word in article.Text)
            {
                if (!uniqueWords.Contains(word.ToLower()))
                    uniqueWords.Add(word.ToLower());
            }

            return uniqueWords.Count;
        }
    }
}
