using System;

namespace Logic.Extractors
{
    public static class WordsUpperCaseCounterExtractor
    {
        public static double ComputeFactor(Article article)
        {
            int countOfMatches = 0;

            foreach(string word in article.Text)
            {
                countOfMatches++; 
                foreach(char c in word)
                {
                    if (!Char.IsUpper(c))
                    {
                        countOfMatches--;
                        break;
                    }
                }
            }

            return countOfMatches;
        }
    }
}
