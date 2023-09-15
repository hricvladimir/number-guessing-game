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
                // Create a file to write to.
                using (var sw = File.CreateText(_path))
                {
                    sw.WriteLine("name,score,guessLimit,numberOfGuesses,time");
                    var score = CalculateScore(guessLimit, numberOfGuesses, time);
                    sw.WriteLine($"{name},{score},{guessLimit},{numberOfGuesses},{time}");
                }
            }
            else
            {
                // Open a file to write to.
                using (var sw = new StreamWriter(_path, true))
                {
                    var score = CalculateScore(guessLimit, numberOfGuesses, time);
                    sw.WriteLine($"{name},{score},{guessLimit},{numberOfGuesses},{time}");
                }
            }
        }

        public double CalculateScore(int guessLimit, int numberOfGuesses, double time)
        {
            // Define weights for each parameter (you can adjust these as needed)
            var guessLimitWeight = 0.3;
            var numberOfGuessesWeight = 0.4;
            var timeWeight = 0.3;

            // Calculate the score based on the weighted parameters
            double score = (
                (1 - (double)guessLimit / Math.Max(guessLimit, 1)) * guessLimitWeight +
                (1 - (double)numberOfGuesses / Math.Max(numberOfGuesses, 1)) * numberOfGuessesWeight +
                (1 - (double)time / Math.Max(time, 0.001)) * timeWeight
            );

            return score;
            
        }
    }
}