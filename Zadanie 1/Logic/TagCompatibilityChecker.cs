using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class TagCompatibilityChecker
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

        public static List<Article> CheckTags(List<Article> articles, string tagName)
        {
            List<Article> compatibleArticles = new List<Article>();

            foreach (Article article in articles)
            {
                foreach(var tag in article.Tags)
                {
                    if (tag.Key == tagName)
                    {
                        if (tagName == "places")
                        {
                            if (tag.Value.Count != 1)
                                break;

                            foreach(string place in tag.Value)
                            {
                                if (correctPlaces.Contains(place))
                                {
                                    article.SelectedTagValues = tag.Value;
                                    compatibleArticles.Add(article);
                                }
                            }
                        }
                        else
                        {
                            article.SelectedTagValues = tag.Value;
                            compatibleArticles.Add(article);
                        }

                    }
                }
            }

            return compatibleArticles;
        }
    }
}
