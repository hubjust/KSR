using System.Collections.Generic;

namespace KSR
{
    public class Article
    {
        public string Title { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }
        public List<string> Words { get; set; }
    }
}
