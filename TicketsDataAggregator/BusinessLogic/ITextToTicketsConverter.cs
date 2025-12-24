
namespace TicketsDataAggregator.BusinessLogic
{
    public interface ITextToTicketsConverter
    {
        IEnumerable<Ticket> Convert(string text);
    }
}