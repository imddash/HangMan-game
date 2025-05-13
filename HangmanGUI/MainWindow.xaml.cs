using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HangmanGUI
{
    public partial class MainWindow : Window
    {
        // ASCII art for each hangman stage
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

        // Game state fields
        private string selectedWord = string.Empty;
        private char[] displayWord = Array.Empty<char>();
        private int attemptsLeft;
        private List<char> guessedLetters = new();

        private bool isDarkTheme = true;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            selectedWord = GetWord();
            displayWord = new string('_', selectedWord.Length).ToCharArray();
            attemptsLeft = 6;
            guessedLetters.Clear();
            UpdateUI();
        }

        private void UpdateUI()
        {
            WordDisplay.Text = string.Join(" ", displayWord);
            GuessedLetters.Text = $"Guessed Letters: {string.Join(", ", guessedLetters)}";
            AttemptsLeft.Text = $"Attempts Left: {attemptsLeft}";
            HangmanTextBlock.Text = hangmanStages[6 - attemptsLeft];
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            string input = LetterInput.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                MessageBox.Show("❌ Enter a single valid letter (a-z).", "Invalid Input");
                return;
            }

            char guess = input[0];

            if (guessedLetters.Contains(guess))
            {
                MessageBox.Show("❗ You already guessed that letter!");
                return;
            }

            guessedLetters.Add(guess);

            if (selectedWord.Contains(guess))
            {
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == guess)
                        displayWord[i] = guess;
                }
            }
            else
            {
                attemptsLeft--;
            }

            UpdateUI();
            CheckGameStatus();
        }

        private void CheckGameStatus()
        {
            if (!displayWord.Contains('_'))
            {
                MessageBox.Show($"🎉 You won! The word was: {selectedWord}", "Victory!");
                StartGame();
            }
            else if (attemptsLeft <= 0)
            {
                MessageBox.Show($"💀 Game over! The word was: {selectedWord}", "Defeat");
                StartGame();
            }
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            ToggleTheme();
        }

        private void ToggleTheme()
        {
            if (isDarkTheme)
            {
                Background = Brushes.White;
                WordDisplay.Foreground = Brushes.Black;
                GuessedLetters.Foreground = Brushes.Black;
                AttemptsLeft.Foreground = Brushes.Black;
                HangmanTextBlock.Foreground = Brushes.Black;
            }
            else
            {
                Background = Brushes.Black;
                WordDisplay.Foreground = Brushes.White;
                GuessedLetters.Foreground = Brushes.White;
                AttemptsLeft.Foreground = Brushes.White;
                HangmanTextBlock.Foreground = Brushes.White;
            }

            isDarkTheme = !isDarkTheme;
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private static string GetWord()
        {
            var path = "words.txt";
            var words = File.ReadAllLines(path);
            Random rand = new();
            return words[rand.Next(words.Length)].Trim().ToLower();
        }

    }
}
