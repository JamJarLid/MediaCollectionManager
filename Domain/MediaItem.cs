namespace MediaCollectionManager.Domain;

abstract class MediaItem
{
    private const int MinimumRating = 1;
    private const int MaximumRating = 10;
    public string Title { get; private set; }

    public int Rating { get; private set; }

    public MediaItem(string title, int rating)
    {
        Title = title;
        Rating = MinimumRating <= rating && rating <= MaximumRating ? 
            rating : throw new ArgumentOutOfRangeException(
                "Invalid rating number: Please choose a number between 1 and 10.");
    }

}