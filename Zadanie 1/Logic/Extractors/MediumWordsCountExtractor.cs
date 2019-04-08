using System.Linq;

namespace Logic.Extractors
{
    class MediumWordsCountExtractor : Extractor
    {
        public override double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length >= 4 && p.Length <=7);
        }
    }
}
