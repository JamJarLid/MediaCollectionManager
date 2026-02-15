using MediaCollectionManager.Domain;

namespace MediaCollectionManager.Services;

class GameCollectionService
{
    private List<VideoGame> GameCollection { get; set; }

    public void AddGame(VideoGame game)
    {
        GameCollection.Add(game);
    }

    public string[] ViewGames()
    {
        string[] info = [];
        foreach (VideoGame game in GameCollection)
            info = [.. info, game.ToString()];
        return info;
    }

    public int CountGames()
    {
        return GameCollection.Count;
    }

    public GameCollectionService(List<VideoGame> gameCollection)
    {
        GameCollection = gameCollection;
    }
}