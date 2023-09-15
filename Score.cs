using System;
using System.IO;

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

            // what the fuck is this piece of shit 
            double score = (
                (timeFactor/time) - (guessLimit*2) + numberOfGuesses*2
                
            );

            return score;
            
        }
    }
}