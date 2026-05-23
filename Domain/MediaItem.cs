namespace MediaCollectionManager.Domain;

abstract class MediaItem(string title, int rating)
{
    private const int MinimumRating = 1;
    private const int MaximumRating = 10;
    public string Title { get; private set; } = title;

    public int Rating { get; private set; } = 
        MinimumRating <= rating && rating <= MaximumRating ? 
        rating : throw new ArgumentOutOfRangeException(
            "Invalid rating number: Please choose a number between 1 and 10.");

}