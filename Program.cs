using System;
using System.Collections.Generic;

namespace csharp_rock_paper_scissors
{
  class Program
  {
    static void Main(string[] args)
    {
      // Set replay condition to true
      bool replay = true;

      // Create list of options
      List<String> throws = new List<String>(){
        "Rock", "Paper", "Scissors"
      };

      int gamesPlayed = 0;
      int gamesWon = 0;
      int gamesLost = 0;

      while (replay)
      {

        Console.Clear();
        Console.WriteLine("Hello player! Enter Rock, Paper, or Scissors:");
        // Get player input
        //TODO make sure input is contained in options
        string playerChoice = Console.ReadLine();

        while (!throws.Contains(playerChoice))
        {
          Console.Clear();
          System.Console.WriteLine("Invalid input. Enter Rock, Paper, or Scissors:");
          playerChoice = Console.ReadLine();

        }

        // Pick a random throw
        Random rnj = new Random();
        int rand = rnj.Next(throws.Count);
        string computerThrow = throws[rand];

        // Output throw results to player
        Console.Clear();

        Console.WriteLine($"You threw {playerChoice}!");
        System.Console.WriteLine($"The computer threw {computerThrow}.");

        // Create dictionary of relationships
        // NOTE take note of how this is done 
        Dictionary<String, List<String>> winsAgainst = new Dictionary<String, List<String>>();
        winsAgainst.Add("rock", new List<String> { "scissors" });
        winsAgainst.Add("paper", new List<String> { "rock" });
        winsAgainst.Add("scissors", new List<String> { "paper" });

        // Sanitize inputs
        playerChoice = playerChoice.ToLower();
        computerThrow = computerThrow.ToLower();

        // Compare throws, set winning condition
        gamesPlayed++;

        if (playerChoice == computerThrow)
        {
          System.Console.WriteLine("It's a tie! gg.");
        }
        // NOTE this is pretty neat
        else if (winsAgainst[playerChoice].Contains(computerThrow))
        {
          System.Console.WriteLine("You win! You're a rockstar.");
          gamesWon++;

        }
        else
        {
          System.Console.WriteLine("You lose. Sorry bub.");
          gamesLost++;
        }
        // return counts of games played and games won and lost 
        System.Console.WriteLine($"Out of {gamesPlayed} games played, you have won {gamesWon} and lost {gamesLost}.");

        // ask player if they want to play again 
        System.Console.WriteLine("Do you wish to play again? Y/N");
        string replayChoice = Console.ReadLine().ToLower();
        if (replayChoice != "y")
        {
          replay = false;
        }
      }
    }
  }
}
