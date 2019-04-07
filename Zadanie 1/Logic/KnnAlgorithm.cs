using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class KnnAlgorithm
    {       
        // ChooseKNeighbours
        public static bool Calculate(TestVectorAndTrainingVectors TestAndTrainingPair, int k)
        {
            TestAndTrainingPair.TrainingVectors = TestAndTrainingPair.TrainingVectors.OrderBy(h => h.Distance).ToList(); //sortuje
            var Kneighbours = TestAndTrainingPair.TrainingVectors.Take(k).ToList(); //bierze k sąsiadów

            return CheckPlace(Kneighbours, TestAndTrainingPair.TestVector);
        }

        // sprawdza, czy w państwa z testowych danych znajdują się w podanych przez nas artykułach
        public static bool CheckPlace(List<Article> neighbours, Article testArticle) 
        {
            Dictionary<string, int> howManyPlaces = new Dictionary<string, int>();
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

                if (neighbours.ElementAt(i).Places.FirstOrDefault() != null && howManyPlaces.ContainsKey(neighbours.ElementAt(i).Places.FirstOrDefault())) //zeruje licznik żeby nie powtarzać juz raz dodanych państsw 
                {
                    howManyTimesOccur = 0;
                    continue;
                }

                if(neighbours.ElementAt(i).Places.FirstOrDefault() != null)
                    howManyPlaces.Add(neighbours.ElementAt(i).Places.FirstOrDefault(), howManyTimesOccur);

                howManyTimesOccur = 0;
            }

            howManyPlaces = howManyPlaces.OrderByDescending(x => x.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            List<KeyValuePair<string, int>> result = howManyPlaces.ToList();
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
