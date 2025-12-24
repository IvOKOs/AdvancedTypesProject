namespace TicketsDataAggregator.BusinessLogic
{
    public interface IFileDataProcessor
    {
        void Save(string data, string filePath);
    }
}