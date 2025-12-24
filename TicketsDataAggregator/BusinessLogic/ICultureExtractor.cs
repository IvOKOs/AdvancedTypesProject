using System.Globalization;

namespace TicketsDataAggregator.BusinessLogic
{
    public interface ICultureExtractor
    {
        IFormatProvider GetCultureFromDomain(string text);
    }
}