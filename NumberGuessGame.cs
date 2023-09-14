using System;

namespace ConsoleApplication1.Properties
{
    public class NumberGuessGame
    {
        private int _randomNumber;

        public int RandomNumber
        {
            get => _randomNumber;
            set => _randomNumber = value; 
        }

        private int _numberOfGuesses;

        public int NumberOfGuesses
        {
            get => _numberOfGuesses;
            set => _numberOfGuesses = value;
        }

        private int _guessLimit;

        public int GuessLimit
        {
            get => _guessLimit;
            set => _guessLimit = value;
        }

        private Boolean _isGameWon;

        public Boolean IsGameWon
        {
            get => _isGameWon;
            set => _isGameWon = value;
        }

        private Boolean _isPlaying;

        public Boolean IsPlaying
        {
            get => _isPlaying;
            set => _isPlaying = value;
        }
        private Random Random { get; set; } = new Random();

        public NumberGuessGame()
        {
            this._randomNumber = Random.Next(0, 1000);
            this._numberOfGuesses = 0;
            this._guessLimit = 10;
            this._isGameWon = false;
            this._isPlaying = true;
        }

        public NumberGuessGame(int guessLimit)
        {
            this._randomNumber = Random.Next(0, 1000);
            this._numberOfGuesses = 0;
            this._guessLimit = guessLimit;
            this._isGameWon = false;
            this._isPlaying = true;
        }
        
        public NumberGuessGame(int guessLimit, int upperRange)
        {
            this._randomNumber = Random.Next(0, upperRange);
            this._numberOfGuesses = 0;
            this._guessLimit = guessLimit;
            this._isGameWon = false;
            this._isPlaying = true;
        }

        public Boolean GuessNumber(int number)
        {
            if (!_isPlaying || _numberOfGuesses >= _guessLimit || _isGameWon)
            {
                return false;
            }
            
            if (number == this._randomNumber)
            {
                _isPlaying = false;
                _isGameWon = true;
                return true;
            }

            return false;
        }
        
        
        
    }
}