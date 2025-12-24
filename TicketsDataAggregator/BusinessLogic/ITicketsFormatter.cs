
namespace TicketsDataAggregator.BusinessLogic
{
    public interface ITicketsFormatter
    {
        string Format(IEnumerable<Ticket> tickets);
    }
}