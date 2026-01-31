namespace MediaCollectionManager;

class VideoGame(string name)
{
  public string Name { get; private set; } = name;
}
class Program
{
  static void Main(string[] args)
  {
    VideoGame GodOfWar = new("God Of War");

    Console.WriteLine("Media Collection Manager");
    Console.WriteLine("1. Add Video Game");
    Console.WriteLine("2. View Video Games");
    Console.WriteLine("3. Exit");
  }
}