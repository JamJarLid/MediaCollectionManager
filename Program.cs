using MediaCollectionManager.Domain;

namespace MediaCollectionManager;

class Program
{
  static void Main(string[] args)
  {
    bool running = true;

    VideoGame GodofWar = new("God of War", "Playstation 2", 8);
    VideoGame LocoRoco = new("LocoRoco", "Playstation Portable", 6);
    List<VideoGame> videoGames = [GodofWar, LocoRoco];

    while(running)
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
          Console.WriteLine("Selected Add Video Game (not implemented)");
          Pause();
          break;
        case "2":
          Console.WriteLine("Selected View Video Games");
          foreach (VideoGame game in videoGames)
          {
            Console.WriteLine("------");
            Console.WriteLine(game);
          }
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
}