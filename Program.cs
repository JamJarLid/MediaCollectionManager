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
          AddMediaItem(mediaCollection, "Game");
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
          AddMediaItem(mediaCollection, "Book");
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

  static void AddMediaItem(MediaCollectionService mediaCollection, string type)
  {
    string title = string.Empty;
    int rating = -1;
    string platform = string.Empty;
    string author = string.Empty;
    int pageCount = 0;
    string pageCountString = string.Empty;
    string ratingString = string.Empty;
    bool ratingParseDone = false;

    //I wanted to use the class as condition, but I wasnt sure how
    if (type == "Game")
    {
      do
      {
        Console.WriteLine("Please enter the platform:");
        platform = Console.ReadLine();
      } while (string.IsNullOrEmpty(platform));
    }
    if (type == "Book")
    {
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
      } while (pageCount > 0);
    }
    do
    {
      Console.WriteLine("Please enter the title:");
      title = Console.ReadLine();
    } while (string.IsNullOrEmpty(title));
    do
    {
      Console.WriteLine("Please enter your rating (1-10):");
      ratingString = Console.ReadLine();
      ratingParseDone = int.TryParse(ratingString, out rating) && rating <= 10 && rating > 0;
    } while (!ratingParseDone);

    if(type == "Game")
    {
      VideoGame newGame = new(platform: platform, title: title, rating: rating);
      mediaCollection.AddMediaItem(newGame);
    }
    if (type == "Book")
    {
      Book newBook = new(author: author, pageCount: pageCount, title: title, rating: rating);
      mediaCollection.AddMediaItem(newBook);
    }
  }

  static string ViewMediaItems(MediaCollectionService mediaCollection)
  {
    string info = string.Empty;
    int count  = mediaCollection.CountMediaItems();
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