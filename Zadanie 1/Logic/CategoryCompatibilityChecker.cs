using System.Collections.Generic;

namespace Logic
{
    public static class CategoryCompatibilityChecker
    {
        private static readonly List<string> correctPlaces = new List<string>
        {
            "west-germany",
            "usa",
            "france",
            "uk",
            "canada",
            "japan"
        };

        private static readonly List<string> correctTopics = new List<string>
        {
            "gold",
            "cocoa",
            "sugar",
            "coffe",
            "grain"
        };

        public static List<Article> CheckTags(List<Article> articles, string categoryName)
        {
            List<Article> compatibleArticles = new List<Article>();

            foreach (Article article in articles)
            {
                foreach(var tag in article.Tags)
                {
                    if (tag.Key == categoryName)
                    {
                        if (tag.Value.Count != 1)
                            break;

                        if (categoryName == "places")
                        {
                            foreach(string place in tag.Value)
                            {
                                if (correctPlaces.Contains(place))
                                {
                                    article.SelectedTag = tag.Value;
                                    compatibleArticles.Add(article);
                                }
                            }
                        }
                        else if(categoryName == "topics")
                        {
                            foreach (string topic in tag.Value)
                            {
                                if (correctTopics.Contains(topic))
                                {
                                    article.SelectedTag = tag.Value;
                                    compatibleArticles.Add(article);
                                }
                            }
                        }
                        else
                        {
                            article.SelectedTag = tag.Value;
                            compatibleArticles.Add(article);
                        }

                    }
                }
            }

            return compatibleArticles;
        }
    }
}
