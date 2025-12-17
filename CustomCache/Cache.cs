

// cache = generic class
// type params will reflect the type of key of some data and the type of data
// cache to be instance of slow data downloader


//Console.WriteLine(dataDownloader.DownloadData(1));
//Console.WriteLine(dataDownloader.DownloadData(2));
//Console.WriteLine(dataDownloader.DownloadData(3));
//Console.WriteLine(dataDownloader.DownloadData(1));
//Console.WriteLine(dataDownloader.DownloadData(2));
//Console.WriteLine(dataDownloader.DownloadData(3));

public class Cache<T, U>
{
    private readonly Dictionary<T, U> _cache = new Dictionary<T, U>();

    public void AddData(T key, U value)
    {
        _cache[key] = value;
    }

    public Tuple<bool, U> GetData(T key)
    {
        U value = default;
        if (!_cache.ContainsKey(key))
        {
            return new Tuple<bool, U>(false, value);
        }
        value = _cache[key];
        return new Tuple<bool, U>(true, value);
    }
}
