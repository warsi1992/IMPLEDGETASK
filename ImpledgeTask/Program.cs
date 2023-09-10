using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xunit;

namespace ImpledgeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long elapsedMilliseconds;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            CompoundedWordFinder co = new CompoundedWordFinder(@"C:\Users\gulam.waris\Desktop\ImpledgeTask\ImpledgeTask\Input_01.txt");
            stopwatch.Stop();
            elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Time taken to process file Input_01.txt: {elapsedMilliseconds} milliseconds");
            Console.ReadLine();
            stopwatch.Start();
            CompoundedWordFinder cos = new CompoundedWordFinder(@"C:\Users\gulam.waris\Desktop\ImpledgeTask\ImpledgeTask\Input_02.txt");
            stopwatch.Stop();
            elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Time taken to process file Input_02.txt: {elapsedMilliseconds} milliseconds");
            Console.WriteLine("Do You Want to Execute the test Case!");
            var val = Console.ReadLine();
            if (val == "Y" || val == "y")
            {
                Test t1 = new Test();
            }
            
        }
    }

    public class CompoundedWordFinder
    {
        public CompoundedWordFinder()
        {

        }
        public CompoundedWordFinder( string filepath)
        {
            string filePath = filepath; 
            List<string> lines = ReadTextFile(filePath);
            try {
                FindLongestAndSecondLongestCompoundedWords(lines);
            }
            catch (Exception EX)
            {

                Console.WriteLine("ERROR: " + EX.Message);
                
            }
            
        }
        public (string Longest, string SecondLongest) FindLongestAndSecondLongestCompoundedWords(List<string> words)
        {
            try
            {
                var wordSet = new HashSet<string>(words);
                string longestCompoundedWord = null;
                string secondLongestCompoundedWord = null;

                foreach (var word in words)
                {
                    wordSet.Remove(word);
                    if (IsCompoundedWord(word, wordSet))
                    {
                        if (longestCompoundedWord == null || word.Length > longestCompoundedWord.Length)
                        {
                            secondLongestCompoundedWord = longestCompoundedWord;
                            longestCompoundedWord = word;
                        }
                        else if (secondLongestCompoundedWord == null || word.Length > secondLongestCompoundedWord.Length)
                        {
                            secondLongestCompoundedWord = word;
                        }
                    }
                    wordSet.Add(word);
                }
                Console.WriteLine("Longest Compound Word: " + longestCompoundedWord);
                Console.WriteLine("Second Longest Compound Word: " + secondLongestCompoundedWord);

                return (longestCompoundedWord, secondLongestCompoundedWord);
            }
            catch (Exception EX)
            {

                Console.WriteLine("ERROR: " + EX.Message);
                return ("ERROR", EX.Message);
            }
           
        }

        private bool IsCompoundedWord(string word, HashSet<string> wordSet)
        {
            try
            {
                if (string.IsNullOrEmpty(word))
                    return false;

                if (wordSet.Contains(word))
                    return true;

                for (int i = 1; i <= word.Length; i++)
                {
                    var prefix = word.Substring(0, i);
                    var suffix = word.Substring(i);

                    if (wordSet.Contains(prefix) && IsCompoundedWord(suffix, wordSet))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception EX)
            {

                Console.WriteLine("ERROR: " + EX.Message);
                return false;
            }

           
        }
        static List<string> ReadTextFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return lines;
        }
    }
}
    



