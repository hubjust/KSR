using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

using Annytab.Stemmer;
using HtmlAgilityPack;
using StopWord;

namespace Logic
{
    public static class FileReader
    {
        private static Stemmer englishStemmer = new EnglishStemmer();

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

                        article.Title = articleNode.Descendants("TITLE").First().InnerText;
                        article.Title = article.Title.Replace("&lt;", "<");
                        article.Tags = tags;
                        article.Text = rawText.ConvertRawTextToList();

                        articles.Add(article);
                    }
                }
            }

            Debug.WriteLine("Articles loaded: " + articles.Count());
            return articles;
        }

        public static List<string> ConvertRawTextToList(this string rawText)
        {
            List<string> textList;

            // Pozbycie się znaków & cyfr
            rawText = rawText.Replace("&#3;", "");
            rawText = rawText.Replace("&lt;", ""); // <
            rawText = rawText.Replace(".", "");
            rawText = rawText.Replace(",", "");
            rawText = rawText.Replace("<", "");
            rawText = rawText.Replace(">", "");
            rawText = rawText.Replace("(", "");
            rawText = rawText.Replace(")", "");
            rawText = rawText.Replace("[", "");
            rawText = rawText.Replace("]", "");
            rawText = rawText.Replace(":", "");
            rawText = rawText.Replace(";", "");
            rawText = rawText.Replace("+", "");
            rawText = rawText.Replace("?", "");
            rawText = rawText.Replace("\"", ""); // "
            rawText = rawText.Replace("\\", ""); // \

            // Zamiana na białe znaki
            rawText = rawText.Replace("/", " ");
            rawText = rawText.Replace(" - ", " ");
            rawText = rawText.Replace(" -- ", " ");
            rawText = Regex.Replace(rawText, "[0-9]{1,}", "");

            // Pozbycie się zbędnych białych znaków
            rawText = Regex.Replace(rawText, @"\s+", " ");

            // Stop Lista
            // Żródło: https://github.com/hklemp/dotnet-stop-words
            rawText = rawText.RemoveStopWords("en");
            rawText = rawText.Replace("Reuter", "");
            rawText = rawText.Replace("REUTER", "");
            rawText = Regex.Replace(rawText, @"\s+", " ");

            // Podzielenie tekstu
            rawText = rawText.TrimStart();
            rawText = rawText.TrimEnd();
            textList = rawText.Split(' ', '\n', '\t').ToList();

            // Stemming 
            // Źródło: http://snowball.tartarus.org/algorithms/english/stemmer.html
            for (int i = 0; i < textList.Count(); i++)
                textList[i] = englishStemmer.GetSteamWord(textList[i]);

            return textList;
        }
    }
}
