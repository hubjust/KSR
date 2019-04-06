using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class KnnAlgorithm
    {
        public static bool Calculate(TestVectorAndTrainingVectors testAndTrainingVectors, int k)
        {
            return ChooseKNeighbours(testAndTrainingVectors, k);
        }

        public static bool ChooseKNeighbours(TestVectorAndTrainingVectors TestAndTrainingPair, int k)
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
                    if (neighbours.ElementAt(i).Places.First() == neighbours.ElementAt(j).Places.First())
                    {
                        howManyTimesOccur++;
                    }
                }

                if (howManyPlaces.ContainsKey(neighbours.ElementAt(i).Places.First())) //zeruje licznik żeby nie powtarzać juz raz dodanych państsw 
                {
                    howManyTimesOccur = 0;
                    continue;
                }

                howManyPlaces.Add(neighbours.ElementAt(i).Places.First(), howManyTimesOccur);
                howManyTimesOccur = 0;
            }

            howManyPlaces = howManyPlaces.OrderByDescending(x => x.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            List<KeyValuePair<string, int>> result = howManyPlaces.ToList();
            var FoundPlace = result.First().Key;

            if (testArticle.Places.First().Equals(FoundPlace))
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
