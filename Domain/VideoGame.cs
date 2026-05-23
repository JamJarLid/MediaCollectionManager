namespace MediaCollectionManager.Domain;

class VideoGame : MediaItem
{
    public string Platform { get; private set; }

    public override string ToString()
    {
        string title = $"Title: {this.Title}";
        string platform = $"Platform: {this.Platform}";
        string rating = $"Rating: {this.Rating}/10";
        return $"{title}\n{platform}\n{rating}";
    }

    public VideoGame(string platform, string title, int rating) : base(title, rating)
    {
        Platform = platform;
    }
}
