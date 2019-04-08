using System.Linq;

namespace Logic.Extractors
{
    public static class LongWordsCounterExtractor
    {
        public static double ComputeFactor(Article article)
        {
            return article.Text.Count(p => p.Length >= 8);
        }
    }
}
