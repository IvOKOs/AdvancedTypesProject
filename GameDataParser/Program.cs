using System.Text.Json;

var app = new App(new UserInteraction(), new GameFileReader(), new GameRepository(new UserInteraction()), new Logger());
app.Run();

public class App
{
    private IUserInteraction _userInteraction;
    private IGameFileReader _fileReader;
    private IGameRepository _gameRepository;
    private ILogger _logger;

    public App(IUserInteraction userInteraction, IGameFileReader fileReader, IGameRepository gameRepository, ILogger logger)
    {
        _userInteraction = userInteraction;
        _fileReader = fileReader;
        _gameRepository = gameRepository;
        _logger = logger;
    }

    public void Run()
    {
        try
        {
            var userInput = _userInteraction.SelectFileName();
            var games = _fileReader.ReadDataFromJson(userInput);
            if (_gameRepository.GamesExist(games))
            {
                _gameRepository.PrintGames(games);
            }
            else
            {
                _userInteraction.PrintMessage("No games are present in the input file.");
            }
        }
        catch(JsonParsingException ex)
        {
            _userInteraction.PrintMessage($"JSON in the {ex.FileName} was not in a valid format. JSON body:");
            _userInteraction.PrintMessage(ex.JsonBody);
            _userInteraction.PrintMessage("Sorry! The application has experienced an unexpected error and will have to be closed.\n");
            _logger.Log(DateTime.Now, ex.Message, ex.StackTrace ?? "No stack trace");
        }
        catch (Exception ex)
        {
            _userInteraction.PrintMessage(ex.Message + "\n");
            _logger.Log(DateTime.Now, ex.Message, ex.StackTrace ?? "No stack trace");
        }
        finally
        {
            _userInteraction.Exit();
        }
    }
}


public class Game
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

    public override string ToString()
    {
        return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
    }
}

public class GameRepository : IGameRepository
{
    private IUserInteraction _userInteraction;

    public GameRepository(IUserInteraction userInteraction)
    {
        _userInteraction = userInteraction;
    }

    public void PrintGames(IEnumerable<Game> games)
    {
        _userInteraction.PrintMessage("Loaded games are:");
        foreach(var game in games)
        {
            Console.WriteLine(game);
        }
    }

    public bool GamesExist(IEnumerable<Game> games)
    {
        return games.Count() > 0;
    }
}

public interface IGameRepository
{
    void PrintGames(IEnumerable<Game> games);
    bool GamesExist(IEnumerable<Game> games);
}

public class Logger : ILogger
{
    private const string FileName = "log.txt";
    public void Log(DateTime date, string message, string stackTrace)
    {
        string fileContents = "";
        if (File.Exists(FileName))
        {
            fileContents = File.ReadAllText(FileName);
        }
        var log = $"[{date}], Exception message: {message}, Stack trace: {stackTrace}\n\n";
        fileContents += log ;
        File.WriteAllText(FileName, fileContents);
    }
}

public interface ILogger
{
    void Log(DateTime date, string message, string stackTrace);
}

public interface IGameFileReader
{
    List<Game> ReadDataFromJson(string fileName);
}

public class GameFileReader : IGameFileReader
{
    public List<Game> ReadDataFromJson(string fileName)
    {
        try
        {
            var fileContent = File.ReadAllText(fileName);
            List<Game> games = JsonSerializer.Deserialize<List<Game>>(fileContent);
            return games;
        }
        catch(JsonException ex)
        {
            var content = File.ReadAllText(fileName);
            throw new JsonParsingException(ex.Message, ex.InnerException, content, fileName);
        }
    }
}

[Serializable]
public class JsonParsingException : Exception
{
    public string JsonBody { get; }
    public string FileName { get; }

    public JsonParsingException()
    {
    }

    public JsonParsingException(string? message) : base(message)
    {
    }

    public JsonParsingException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public JsonParsingException(string? message, Exception? innerException, string jsonBody, string fileName) : base(message, innerException)
    {
        JsonBody = jsonBody;
        FileName = fileName;
    }
}

public interface IUserInteraction
{
    void PrintMessage(string message);
    string SelectFileName();
    void Exit();
}

public class UserInteraction : IUserInteraction
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string SelectFileName()
    {
        string fileName = "";
        while (true)
        {
            PrintMessage("Enter the name of the file you want to read:");
            fileName = Console.ReadLine();
            if(!IsInputValid(fileName))
            {
                continue;
            }
            break;
        }
        return fileName;
    }

    public void Exit()
    {
        PrintMessage("Press any key to close.");
        Console.ReadKey();
    }

    private bool IsInputValid(string fileName)
    {
        if (fileName == null)
        {
            PrintMessage("File name cannot be null.");
            return false;
        }
        if (fileName == string.Empty)
        {
            PrintMessage("File name cannot be empty.");
            return false;
        }
        if (!File.Exists(fileName))
        {
            PrintMessage("File not found.");
            return false;
        }
        return true;
    }
}
