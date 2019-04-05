using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Article
    {
        public string Title { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }
        public List<string> Words { get; set; }

        private double CountFrequency(Article article, string word)
        {
            return article.Words.Count(s => s.Equals(word, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
