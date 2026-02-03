namespace MediaCollectionManager;

class Program
{
  static void Main(string[] args)
  {
    bool running = true;

    while(running)
    {
      Console.Clear();
      Console.WriteLine("---JAMJARLIB MEDIA COLLECTION MANAGER---");
      Console.WriteLine("1. Add video game");
      Console.WriteLine("2. View video games");
      Console.WriteLine("3. Exit");
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
          Console.WriteLine("Selected View Video Games (not implemented)");
          Pause();
          break;
        case "3":
          Console.WriteLine("Program exited");
          running = false;
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