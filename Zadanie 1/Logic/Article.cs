using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Article
    {
        public string Title { get; set; }
        public List<string> Text { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }

        // nie wiem co

        public Dictionary<string, double> VectorFeatures;
        public double Distance { get; set; }


    }
}
