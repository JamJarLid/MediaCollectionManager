using MediaCollectionManager.Domain;

namespace MediaCollectionManager.Services;

class MediaCollectionService
{
    private List<MediaItem> MediaCollection { get; }

    public void AddMediaItem(MediaItem mediaItem)
    {
        MediaCollection.Add(mediaItem);
    }

    public IReadOnlyList<MediaItem> GetMediaItems()
    {
        return MediaCollection;
    }
    public int CountMediaItems()
    {
        return MediaCollection.Count;
    }

    public MediaCollectionService(List<MediaItem> mediaCollection)
    {
        MediaCollection = mediaCollection;
    }
}