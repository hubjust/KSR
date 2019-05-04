using System.Linq;

namespace Logic.Extractors
{
    public static class MediumWordsCountExtractor
    {
        public static double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length >= 4 && p.Length <=7);
        }
    }
}
