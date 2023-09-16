using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    public class Score
    {
        private string _path = @"../score.txt";

        public void WriteScore(String name, int guessLimit, int numberOfGuesses, double time)
        {
            if (!File.Exists(_path))
            {
                
                using (var sw = File.CreateText(_path))
                {
                    sw.WriteLine("name,score,guessLimit,numberOfGuesses,time");
                    var score = CalculateScore(guessLimit, numberOfGuesses, time);
                    sw.WriteLine($"{name},{score},{guessLimit},{numberOfGuesses},{time}");
                }
            }
            else
            {
                
                using (var sw = new StreamWriter(_path, true))
                {
                    var score = CalculateScore(guessLimit, numberOfGuesses, time);
                    sw.WriteLine($"{name},{score},{guessLimit},{numberOfGuesses},{time}");
                }
            }
        }

        public double CalculateScore(int guessLimit, int numberOfGuesses, double time)
        {
            var timeFactor = 10000;
            double score = (
                (timeFactor/time) - (guessLimit*2) + numberOfGuesses*2
                
            );
            return score;
        }

        public double GetTopScoreByName(String name)
        {
            var topList = new List<string>();
            var regexNameScore = new Regex($"{name},[0-9]+\\.[0-9]+", RegexOptions.IgnoreCase);
            var regexScore = new Regex("[0-9]*\\.[0-9]+", RegexOptions.IgnoreCase);
            using (var sr = new StreamReader(_path))
            {

                var line = sr.ReadLine();
                while (line != null)
                {
                    // Console.WriteLine(line);
                    if(regexScore.IsMatch(regexNameScore.Match(line).ToString()))
                        topList.Add(regexScore.Match(regexNameScore.Match(line).ToString()).ToString());
                    line = sr.ReadLine();
                }
            }
            var topListDouble = topList.Select(double.Parse).ToList();
            return topListDouble.Count>0 ? topListDouble.Max() : 0;
        }
    }
}