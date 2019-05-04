using System;
using System.Collections.Generic;

namespace Logic.Extractors
{
    public static class UniqueWordsCounterExtractor
    {
        public static double ComputeFactor(Article article)
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
