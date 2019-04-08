using System.Linq;

namespace Logic.Extractors
{
    class LongWordsCounterExtractor : Extractor
    {
        public override double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length >= 8);
        }
    }
}
