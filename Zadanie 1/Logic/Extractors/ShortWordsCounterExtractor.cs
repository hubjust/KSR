using System.Linq;

namespace Logic.Extractors
{
    class ShortWordsCounterExtractor : Extractor
    {
        public override double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length <= 3);
        }
    }
}
