using System.Collections.Generic;
using System.Linq;

namespace Logic.Extractors
{
    public static class WordsCounterExtractor
    {
        public static double ComputeFactor(Article article)
        {
            return article.Text.Count();
        }
    }
}
