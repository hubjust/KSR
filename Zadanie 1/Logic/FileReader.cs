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
                    var body = articleNode.Descendants("BODY").FirstOrDefault();
                    var tags = new Dictionary<string, List<string>>();

                    foreach (var tagNode in articleNode.ChildNodes.Where(node => node.ChildNodes.Any(htmlNode => htmlNode.Name == "d")))
                    {
                        tags[tagNode.Name] = tagNode.Descendants("D").Select(node => node.InnerText).ToList();
                    }

                    if (body != null && tags.Count > 0)
                    {
                        Article article = new Article();

                        string rawText = articleNode.Descendants("BODY").FirstOrDefault().InnerText;
                        rawText = rawText.Replace("&lt;", "<");
                        rawText = rawText.Replace("\r\n", " ");
                        rawText = rawText.Replace("     ", " ");
                        rawText = rawText.Replace(" &#3;", "");

                        article.Title = articleNode.Descendants("TITLE").First().InnerText;
                        article.Tags = tags;
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
