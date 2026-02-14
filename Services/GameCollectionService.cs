using MediaCollectionManager.Domain;

namespace MediaCollectionManager.Services;

class GameCollectionService
{
    private List<VideoGame> GameCollection { get; set; }

    public void AddGame(VideoGame game)
    {
        GameCollection.Add(game);
    }

    public string ViewGames()
    {
        string info = string.Empty;
        foreach (VideoGame game in GameCollection)
            info += $"{game}\n------\n";
        return info;
    }

    public int CountGames()
    {
        int count = 0;
        foreach (VideoGame game in GameCollection)
            count ++;
        return count;
    }

    public GameCollectionService()
    {
        VideoGame GodofWar = new("God of War", "Playstation 2", 8);
        VideoGame LocoRoco = new("LocoRoco", "Playstation Portable", 6);
        GameCollection =[ GodofWar, LocoRoco ];
    }
}