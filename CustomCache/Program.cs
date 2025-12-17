// cache = generic class
// type params will reflect the type of key of some data and the type of data
// cache to be instance of slow data downloader
using CustomCache.Repositories;

IDataDownloader<string, string> dataDownloader = new SlowDataDownloader(new Cache<string, string>(),
                                                        new StringsRepository());

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

//Console.WriteLine(dataDownloader.DownloadData(1));
//Console.WriteLine(dataDownloader.DownloadData(2));
//Console.WriteLine(dataDownloader.DownloadData(3));
//Console.WriteLine(dataDownloader.DownloadData(1));
//Console.WriteLine(dataDownloader.DownloadData(2));
//Console.WriteLine(dataDownloader.DownloadData(3));

Console.ReadKey();


public interface IDataDownloader<T, U>
{
    U DownloadData(T resourceId);
}

public class SlowDataDownloader : IDataDownloader<string, string>
{
    private readonly Cache<string, string> _cache;
    private readonly IRepository<string, string> _stringsRepository;
    //private readonly IRepository<int, DateTime> _datetimeRepository;

    public SlowDataDownloader(Cache<string, string> cache, IRepository<string, string> _repository)
    {
        _cache = cache;
        _stringsRepository = _repository;
        //_datetimeRepository = _repository;
    }

    public string DownloadData(string resourceId)
    {
        Tuple<bool, string> data = _cache.GetData(resourceId);
        if (!data.Item1)
        {
            string dbData = _stringsRepository.GetById(resourceId);
            _cache.AddData(resourceId, dbData);
            return dbData;
        }
        return data.Item2;
    }
}
