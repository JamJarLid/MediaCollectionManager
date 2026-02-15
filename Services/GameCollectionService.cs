using MediaCollectionManager.Domain;

namespace MediaCollectionManager.Services;

class GameCollectionService
{
    private List<VideoGame> GameCollection { get; }

    public void AddGame(VideoGame game)
    {
        GameCollection.Add(game);
    }

    public List<VideoGame> ViewGames()
    {
        List<VideoGame> info = GameCollection;
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