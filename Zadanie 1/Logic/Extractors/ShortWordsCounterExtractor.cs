using System.Linq;

namespace Logic.Extractors
{
    class ShortWordsCounterExtractor : IExtractor
    {
        public double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length <= 3);
        }
    }
}
