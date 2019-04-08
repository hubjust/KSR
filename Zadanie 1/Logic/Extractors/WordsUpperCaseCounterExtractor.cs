using System.Collections.Generic;
using System.Linq;

namespace Logic.Extractors
{
    class WordsUpperCaseCounterExtractor : IExtractor
    {
        public double ComputeFactor(Article article)
        {
            return article.Text.Count();
        }
    }
}
