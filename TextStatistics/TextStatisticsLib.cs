using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextStatistics
{
    public class TextStatisticsLib
    {
        public static string _text;
        public TextStatisticsLib(string text)
        {
            _text = text;
        }

        public int CountWords()
        {
            if (string.IsNullOrWhiteSpace(_text))
                return 0;

            string[] darabol = _text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            return darabol.Length;
        }

        public int CountSentences()
        {
            if (string.IsNullOrWhiteSpace(_text))
                return 0;

            var cleaned = Regex.Replace(_text, @"[.!?]+", "|");
            return cleaned.Count(c => c == '|');
        }

        public string MostCommonWord()
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
        public static void Main(string[] args)
        {
            TextStatisticsLib text = new TextStatisticsLib("Ez egy mondat egy teszteléshez!");

            Console.WriteLine(text.CountWords());
            Console.WriteLine(text.CountSentences());
            Console.WriteLine(text.MostCommonWord());
        }
    }
}
