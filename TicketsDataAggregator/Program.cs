// See https://aka.ms/new-console-template for more information

using TicketsDataAggregator.BusinessLogic;
using TicketsDataAggregator.UI;

var app = new App(new PdfTicketsExtractor(new TextToTicketsConverter(new CultureExtractor())),
                  new TicketsFormatter(),
                  new FileDataProcessor(),
                  new ConsoleUserInteraction());
app.Run();

Console.ReadKey();

public class App
{
    private const string Path = @"C:\Users\User\Downloads\Tickets\Tickets";
    private const string FilePath = $@"{Path}\aggregatedTickets.txt";

    private readonly IPdfDataExtractor _pdfDataExtractor;
    private readonly ITicketsFormatter _ticketsFormatter;
    private readonly IFileDataProcessor _fileDataProcessor;
    private readonly IConsoleUserInteraction _consoleUserInteraction;

    public App(IPdfDataExtractor pdfDataExtractor,
               ITicketsFormatter ticketsFormatter,
               IFileDataProcessor fileDataProcessor,
               IConsoleUserInteraction consoleUserInteraction)
    {
        _pdfDataExtractor = pdfDataExtractor;
        _ticketsFormatter = ticketsFormatter;
        _fileDataProcessor = fileDataProcessor;
        _consoleUserInteraction = consoleUserInteraction;
    }

    public void Run()
    {
        try
        {
            var tickets = _pdfDataExtractor.Extract(Path);
            var formattedTickets = _ticketsFormatter.Format(tickets);
            _fileDataProcessor.Save(formattedTickets, FilePath);
            _consoleUserInteraction.ShowMessage($@"Result saved to {FilePath}{Environment.NewLine}Press any key to close.");
        }
        catch(Exception ex)
        {
            _consoleUserInteraction.ShowMessage(ex.Message);
            // log the ex
        }
    }
}
