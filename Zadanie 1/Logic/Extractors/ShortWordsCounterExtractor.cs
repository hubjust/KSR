using System.Linq;

namespace Logic.Extractors
{
    public static class ShortWordsCounterExtractor
    {
        public static double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length <= 3);
        }
    }
}
