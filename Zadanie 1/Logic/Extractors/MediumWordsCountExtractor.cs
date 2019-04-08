using System.Linq;

namespace Logic.Extractors
{
    class MediumWordsCountExtractor : IExtractor
    {
        public double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length >= 4 && p.Length <=7);
        }
    }
}
