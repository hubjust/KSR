using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class KnnAlgorithm
    {       
        // ChooseKNeighbours
        public static bool Calculate(Article testArticle, List<Article> TrainingArticles, int k)
        {
            TrainingArticles = TrainingArticles.OrderBy(h => h.Distance).ToList(); //sortuje
            var neighbours = TrainingArticles.Take(k).ToList(); //bierze k sąsiadów

            return CheckTag(testArticle, neighbours);
        }

        // sprawdza, czy w państwa z testowych danych znajdują się w podanych przez nas artykułach
        private static bool CheckTag(Article testArticle, List<Article> neighbours) 
        {
            Dictionary<string, int> howManyTags = new Dictionary<string, int>();
            int howManyTimesOccur = 0;

            for (int i = 0; i < neighbours.Count; i++)
            {
                for (int j = 0; j < neighbours.Count; j++)
                {
                    if (neighbours.ElementAt(i).Places.FirstOrDefault() == neighbours.ElementAt(j).Places.FirstOrDefault())
                    {
                        howManyTimesOccur++;
                    }
                }

                if (neighbours.ElementAt(i).Places.FirstOrDefault() != null && howManyTags.ContainsKey(neighbours.ElementAt(i).Places.FirstOrDefault())) //zeruje licznik żeby nie powtarzać juz raz dodanych państsw 
                {
                    howManyTimesOccur = 0;
                    continue;
                }

                if(neighbours.ElementAt(i).Places.FirstOrDefault() != null)
                    howManyTags.Add(neighbours.ElementAt(i).Places.FirstOrDefault(), howManyTimesOccur);

                howManyTimesOccur = 0;
            }

            howManyTags = howManyTags.OrderByDescending(x => x.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            List<KeyValuePair<string, int>> result = howManyTags.ToList();
            var FoundPlace = result.First().Key;

            if (testArticle.Places.FirstOrDefault() != null && testArticle.Places.FirstOrDefault().Equals(FoundPlace))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
