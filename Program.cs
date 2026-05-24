using System.Net;
using MediaCollectionManager.Domain;
using MediaCollectionManager.Services;

namespace MediaCollectionManager;

class Program
{
  static void Main(string[] args)
  {
    bool running = true;

    MediaCollectionService mediaCollection = new(mediaCollection: []);

    while (running)
    {
      Console.Clear();
      Console.WriteLine("---JAMJARLIB MEDIA COLLECTION MANAGER---");
      Console.WriteLine("1. Add video game");
      Console.WriteLine("2. View video games");
      Console.WriteLine("3. Exit");
      Console.WriteLine("4. About");
      Console.WriteLine("5. Add book");
      Console.WriteLine();
      Console.Write("Choose an option: ");

      string? input = Console.ReadLine();

      switch (input)
      {
        case "1":
          Console.WriteLine("Selected Add Video Game");
          AddVideoGame(mediaCollection);
          Pause();
          break;
        case "2":
          Console.WriteLine("Selected View Video Games");
          Console.WriteLine(ViewMediaItems(mediaCollection));
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
        case "5":
          Console.WriteLine("Selected Add Book");
          AddBook(mediaCollection);
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

  static void AddVideoGame(MediaCollectionService mediaCollection)
  {
    string platform = string.Empty;

    do
    {
      Console.WriteLine("Please enter the platform:");
      platform = Console.ReadLine();
    } while (string.IsNullOrEmpty(platform));

    string title = AddTitle();
    int rating = AddRating();

    VideoGame newGame = new(platform: platform, title: title, rating: rating);
    mediaCollection.AddMediaItem(newGame);
  }

  static void AddBook(MediaCollectionService mediaCollection)
  {
    string author = string.Empty;
    int pageCount = 0;
    string pageCountString = string.Empty;

    do
    {
      Console.WriteLine("Please enter the author:");
      author = Console.ReadLine();
    } while (string.IsNullOrEmpty(author));
    do
    {
      Console.WriteLine("Please enter the page count:");
      pageCountString = Console.ReadLine();
      pageCount = int.Parse(pageCountString);
    } while (pageCount <= 0);

    string title = AddTitle();
    int rating = AddRating();

    Book newBook = new(author: author, pageCount: pageCount, title: title, rating: rating);
    mediaCollection.AddMediaItem(newBook);
  }

  static int AddRating()
  {
    int rating = -1;
    string ratingString = string.Empty;
    bool ratingParseDone = false;
    
    do
    {
      Console.WriteLine("Please enter your rating (1-10):");
      ratingString = Console.ReadLine();
      ratingParseDone = int.TryParse(ratingString, out rating) && rating <= 10 && rating > 0;
    } while (!ratingParseDone);

    return rating;
  }

  static string AddTitle()
  {
    string title = string.Empty;
    do
    {
      Console.WriteLine("Please enter the title:");
      title = Console.ReadLine();
    } while (string.IsNullOrEmpty(title));

    return title;
  }

  static string ViewMediaItems(MediaCollectionService mediaCollection)
  {
    string info = string.Empty;
    int count = mediaCollection.CountMediaItems();
    IReadOnlyList<MediaItem> items = mediaCollection.GetMediaItems();
    if (count < 1)
      return "The collection is empty, please add games.";
    else
    {
      foreach (MediaItem item in items)
      {
        info += $"{item}\n------\n";
      }
      return info;
    }
  }
}