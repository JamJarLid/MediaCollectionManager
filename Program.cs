using System.ComponentModel.DataAnnotations;
using MediaCollectionManager.Domain;
using MediaCollectionManager.Services;

namespace MediaCollectionManager;

class Program
{
  static void Main(string[] args)
  {
    bool running = true;

    GameCollectionService gameCollection = new();

    while (running)
    {
      Console.Clear();
      Console.WriteLine("---JAMJARLIB MEDIA COLLECTION MANAGER---");
      Console.WriteLine("1. Add video game");
      Console.WriteLine("2. View video games");
      Console.WriteLine("3. Exit");
      Console.WriteLine("4. About");
      Console.WriteLine();
      Console.Write("Choose an option: ");

      string? input = Console.ReadLine();

      switch (input)
      {
        case "1":
          Console.WriteLine("Selected Add Video Game");
          AddGame(gameCollection);
          Pause();
          break;
        case "2":
          Console.WriteLine("Selected View Video Games");
          Console.WriteLine(ViewGames(gameCollection));
          Pause();
          break;
        case "3":
          Console.WriteLine("Program exited");
          running = false;
          break;
        case "4":
          Console.WriteLine("This program is designed to track and maintain personal physical media collections");
          Pause();
          break;
        default:
          Console.WriteLine("Error: Invalid argument");
          Pause();
          break;
      }
    }
  }
  static void Pause()
  {
    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
  }

  static void AddGame(GameCollectionService gameCollection)
  {
    string title = string.Empty;
    string platform = string.Empty;
    string ratingString = string.Empty;
    int rating;
    bool ratingParseDone = false;
    do
    {
      Console.WriteLine("Please enter the title:");
      title = Console.ReadLine();
    } while (string.IsNullOrEmpty(title));
    do
    {
      Console.WriteLine("Please enter the platform:");
      platform = Console.ReadLine();
    } while (string.IsNullOrEmpty(platform));
    do
    {
      Console.WriteLine("Please enter your rating (1-10):");
      ratingString = Console.ReadLine();
      ratingParseDone = int.TryParse(ratingString, out rating) && rating <= 10 && rating > 0;
    } while (ratingParseDone);

    VideoGame newGame = new(title, platform, rating);
    gameCollection.AddGame(newGame);
  }

  static string ViewGames(GameCollectionService gameCollection)
  {
    string info = string.Empty;
    string[] games = gameCollection.ViewGames();
    if (games.Length < 1)
      return "The collection is empty, please add games.";
    else
    {
      foreach (string game in games)
      {
        info += $"{game}\n------\n";
      }
      return info;
    }
  }
}