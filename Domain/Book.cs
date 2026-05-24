namespace MediaCollectionManager.Domain;

class Book : MediaItem
{
    public string Author { get; private set; }
    public int PageCount { get; private set; }

    public Book(string author, int pageCount, string title, int rating) : base (title, rating)
    {
        Author = author;
        PageCount = pageCount > 0 ? pageCount : 
            throw new ArgumentOutOfRangeException(
                "Invalid page count: Page count must be at least 1.");
    }

    public override string ToString()
    {
        string title = $"Title: {this.Title}";
        string author = $"Author: {this.Author}";
        string pageCount = $"Page Count: {this.PageCount}";
        string rating = $"Rating: {this.Rating}/10";
        return $"{title}\n{author}\n{pageCount}\n{rating}";
    }
}