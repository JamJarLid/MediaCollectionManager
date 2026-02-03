namespace MediaCollectionManager.Domain;

class VideoGame(string title, string platform, int rating)
{
    private const int MinimumRating = 1;
    private const int MaximumRating = 10;
    public string Title { get; private set; } = title;
    public string Platform { get; private set; } = platform;
    public int Rating { get; private set; } = 
        MinimumRating <= rating && rating <= MaximumRating ? 
        rating : throw new InvalidDataException(
            "Invalid rating number: Please choose a number between 1 and 10.");
    

}
