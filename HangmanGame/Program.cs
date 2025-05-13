using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static readonly string[] hangmanStages = new string[]
    {
    @"
  +---+
  |   |
      |
      |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
    };

    static void Main()
    {
        Console.WriteLine("🎮 Welcome to Hangman!");
        PlayHangman();
    }

    static void PlayHangman()
    {
        string chosenWord = GetWord();

        char[] guessedWord = new string('_', chosenWord.Length).ToCharArray();
        List<char> guessedLetters = new List<char>();
        int attemptsLeft = 6;

        while (attemptsLeft > 0 && new string(guessedWord) != chosenWord)
        {
            Console.Clear();
            Console.WriteLine(hangmanStages[6 - attemptsLeft]);
            Console.WriteLine("\nWord: " + string.Join(" ", guessedWord));
            Console.WriteLine("Guessed Letters: " + string.Join(", ", guessedLetters));
            Console.WriteLine("Attempts Left: " + attemptsLeft);

            Console.Write("Guess a letter: ");
            string input = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("❌ Please enter exactly one valid letter (a-z). Press any key to try again...");
                Console.ReadKey();
                continue;
            }


            char guess = input[0];

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter. Press any key...");
                Console.ReadKey();
                continue;
            }

            guessedLetters.Add(guess);

            if (chosenWord.Contains(guess))
            {
                for (int i = 0; i < chosenWord.Length; i++)
                {
                    if (chosenWord[i] == guess)
                        guessedWord[i] = guess;
                }
            }
            else
            {
                attemptsLeft--;
            }
        }

        Console.Clear();
        if (new string(guessedWord) == chosenWord)
        {
            Console.WriteLine("🎉 You won! The word was: " + chosenWord);
        }
        else
        {
            Console.WriteLine(hangmanStages[6]);
            Console.WriteLine("😢 Game over! The word was: " + chosenWord);
        }
    }

    static string GetWord()
    {
        Console.WriteLine("Choose word input method:");
        Console.WriteLine("1. Enter word manually");
        Console.WriteLine("2. Load random word from 'words.txt'");
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter a secret word (it will be hidden): ");
            string word = "";
            ConsoleKeyInfo key;

            // Hide the word input
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                {
                    word += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine("\nWord accepted! Let Player 2 guess...");
            System.Threading.Thread.Sleep(2000); // Pause before clearing
            Console.Clear();
            return word.ToLower();
        }
        else
        {
            try
            {
                string[] words = File.ReadAllLines("words.txt");
                if (words.Length == 0) throw new Exception("File is empty!");
                Random rand = new Random();
                return words[rand.Next(words.Length)].Trim().ToLower();
            }
            catch
            {
                Console.WriteLine("Error reading 'words.txt'. Make sure it exists and has words.");
                Environment.Exit(1);
                return "";
            }
        }
    }
}
