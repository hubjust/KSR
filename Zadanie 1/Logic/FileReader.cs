using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

using HtmlAgilityPack;

namespace Logic
{
    public static class FileReader
    {
        public static IEnumerable<Article> GetArticlesFromFile(string[] filePath)
        {
            Debug.WriteLine("Loading articles...");

            List<Article> articles = new List<Article>();

            for (int i = 0; i < filePath.Length; i++)
            {
                var rawXML = File.ReadAllText(filePath[i]);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(rawXML);

                foreach (var articleNode in htmlDocument.DocumentNode.Descendants("REUTERS"))
                {                    
                    if (articleNode.Descendants("BODY").FirstOrDefault() != null)
                    {
                        Article article = new Article();

                        article.Title = articleNode.Descendants("TITLE").First().InnerText;
                        article.Places = articleNode.Descendants("PLACES").Select(placeNode => placeNode.Descendants("D").Select(node => node.InnerHtml)).First().ToList();

                        string rawText = articleNode.Descendants("BODY").FirstOrDefault().InnerText;
                        rawText = rawText.Replace("&lt;", "<");
                        rawText = rawText.Replace("\r\n", " ");
                        rawText = rawText.Replace("     ", " ");
                        rawText = rawText.Replace(" &#3;", "");

                        article.Text = rawText.Split(' ', '\n', '\t').ToList();

                        articles.Add(article);
                    }
                }
            }

            Debug.WriteLine("Articles loaded: " + articles.Count());
            return articles;
        }
    }
}
