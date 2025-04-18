namespace MediaCollectionManager.Classes;

public class VideoGame(string title, VideoGameConsole _console, DateOnly releaseYear, VideoGameVersion _videoGameVersion, bool owned, bool loaned)
{
  private string Title { get; set; } = title;
  private VideoGameConsole console { get; set; } = _console;
  private DateOnly ReleaseYear { get; set; } = releaseYear;
  private VideoGameVersion videoGameVersion { get; set; } = _videoGameVersion;
  private bool Owned { get; set; } = owned;
  private bool Loaned { get; set; } = loaned;
}
