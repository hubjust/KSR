using System.Linq;

namespace Logic.Extractors
{
    class LongWordsCounterExtractor : IExtractor
    {
        public double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length >= 8);
        }
    }
}
