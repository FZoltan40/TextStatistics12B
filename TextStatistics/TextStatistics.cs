using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextStatistics
{
    internal class TextStatistics
    {
        public static string _text;
        public TextStatistics(string text)
        {
            _text = text;
        }

        public static int CountWords()
        {
            if(string.IsNullOrWhiteSpace(_text))
                return 0;

            string[] darabol = _text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            return darabol.Length;
        }

        public static int CountSentences() 
        {
            if (string.IsNullOrWhiteSpace(_text))
                return 0;

            var cleaned = Regex.Replace(_text, @"[.!?]+", "|");
            return cleaned.Count(c => c == '|');
        }

        public static string MostCommonWord()
        {
            if (string.IsNullOrWhiteSpace(_text))
                return string.Empty;

            var cleaned = Regex.Replace(_text.ToLower(), "[^a-z0-9 ]", "");

            var words = cleaned
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return string.Empty;

            return words
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => Array.IndexOf(words, g.Key))
                .First()
                .Key;
        }
        static void Main(string[] args)
        {
            TextStatistics text = new TextStatistics("Ez egy mondat egy teszteléshez!");
            Console.WriteLine(CountWords());
            Console.WriteLine(CountSentences());
            Console.WriteLine(MostCommonWord());
        }
    }
}
