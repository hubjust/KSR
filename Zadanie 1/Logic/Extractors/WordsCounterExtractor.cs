using System.Collections.Generic;
using System.Linq;

namespace Logic.Extractors
{
    class WordsCounterExtractor : Extractor
    {
        public override double ComputeFactor(Article article)
        {
            return article.Text.Count();
        }
    }
}
