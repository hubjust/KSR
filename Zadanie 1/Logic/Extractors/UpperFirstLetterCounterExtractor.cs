using System;

namespace Logic.Extractors
{
    class UpperFirstLetterCounterExtractor : Extractor
    {
        public override double ComputeFactor(Article article)
        {
            int countOfMatches = 0;

            foreach(string word in article.Text)
            {
                if (Char.IsUpper(word[0]))
                    countOfMatches++;
            }

            return countOfMatches;
        }
    }
}
