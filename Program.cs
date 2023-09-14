using System;
using ConsoleApplication1.Properties;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            NumberGuessGame game = new NumberGuessGame();
            int guess = 0;
            
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("Please enter your name!");
            String name = Console.ReadLine();
            Console.WriteLine($"Welcome, {name}:");
            Console.WriteLine("* --------------------------- *");

            while (game.IsPlaying && !game.IsGameWon)
            {
                Console.WriteLine("\nI am thinking of a number. Try to guess it!");
                Console.Write("Your Guess: ");
                String guessString = Console.ReadLine();
                if (guessString != null)
                {
                    guess = int.Parse(guessString);
                }
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

                if (guess == game.RandomNumber)
                {
                    Console.WriteLine($"Congratulations! The number was {game.RandomNumber}! You won!");
                    break;
                }

                game.GuessLimit += 1;
                if (game.NumberOfGuesses >= game.GuessLimit)
                {
                    Console.WriteLine("You lost!");
                    game.IsPlaying = false;
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
            
            
            
        }
    }
}