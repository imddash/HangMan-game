   M S B A M L   `   `   `  ����  
HangmanGUI    HangmanGUI.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Hangman Game��5   	   $	��450��6   $	��600��6+   .��5      � .+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5	      $
��Auto �6    �� 5
      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$ HangmanTextBlock��5      $��0��5      $��Consolas)�5      $��18(�5      
���   �$��5q�5      �� 5      -   5        $ WordDisplay��5      $��1��5      $��Consolas)�5      $��30(�5      
���   �$��Center=�5      $��5q�5      �� 5"      $��2��6    �� Orientation$ 
Horizontal=�5#      $��Center=�5$      $��Center=�5%      $��5q�5&      .+�5'      �� -   5         ��Name$ LetterInput��5'      $��50��5(      $��20(�5)       �� 	MaxLength$ 1��5*      $��5q�5+      $��Center=�5,      $��Center=�5-      �� 5/      -   5         ��Name$ GuessButton��5/      $��Guess��50      $	��100��51      $��20(�52      $��5q�53      54      55      �� 58      -   5        $ GuessedLetters��58      $��3��59      $��16(�5:      
���   �$��Center=�5<      $��5q�5=      �� 5@      -   5        $ AttemptsLeft��5@      $��4��5A      $��16(�5B      
���   �$��Center=�5D      $��5q�5E      �� 5H      $��5��6   $ 
Horizontal=�5I      $��Center=�5J      $��Center=�5K      .+�5L      �� -   5        $ ToggleThemeButton��5L      $��Toggle Theme��5M      $��16(�5N      $	��120��5O      $��5q�5P      5Q      �� 5R      -   5        $ RestartButton��5R      $��Restart Game��5S      $��16(�5T      $	��120��5U      $��5q�5V      5W      5X      5Y      5Z      5[      