using System;
using System.Diagnostics;
using ConsoleApplication1.Properties;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var game = new NumberGuessGame();
            
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("Please enter your name!");
            var name = Console.ReadLine();
            Console.WriteLine($"Welcome, {name}:");
            Console.WriteLine("* --------------------------- *");
            
            var stopWatch = Stopwatch.StartNew();
            while (game.IsPlaying && !game.IsGameWon)
            {
                var guess = 0;
                Console.WriteLine("\nI am thinking of a number. Try to guess it!");
                Console.Write("Your Guess: ");
                var guessString = Console.ReadLine();
                if (guessString != null) guess = int.Parse(guessString);
                
                else
                {
                    while (guessString == null)
                    {
                        Console.WriteLine("Wrong input!");
                        Console.Write("Your Guess: ");
                        guessString = Console.ReadLine();
                    }
                    guess = int.Parse(guessString);
                }

                game.NumberOfGuesses += 1;

                if (guess == game.RandomNumber)
                {
                    Console.WriteLine($"Congratulations! The number was {game.RandomNumber}! You won!");
                    game.IsGameWon = true;
                    game.IsPlaying = false;
                    break;
                }
                
                if (game.NumberOfGuesses >= game.GuessLimit)
                {
                    Console.WriteLine("You lost!");
                    game.IsPlaying = false;
                    break;
                }
                if (guess > game.RandomNumber && game.IsPlaying)
                {
                    Console.WriteLine("Your number was HIGHER than my number! Try again");
                }
                else
                {
                    Console.WriteLine("Your number was LOWER than my number! Try again");
                }
            }
            stopWatch.Stop();
            if (game.IsGameWon)
            {
                Console.WriteLine($"You guessed the number in {game.NumberOfGuesses} guesses and you did it in {(double)(stopWatch.ElapsedMilliseconds/(double)1000)} seconds.");
            }
        }
    }
}