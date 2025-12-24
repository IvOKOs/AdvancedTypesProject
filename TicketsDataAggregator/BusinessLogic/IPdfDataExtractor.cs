
namespace TicketsDataAggregator.BusinessLogic
{
    public interface IPdfDataExtractor
    {
        IEnumerable<Ticket> Extract(string path);
    }
}