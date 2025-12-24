// See https://aka.ms/new-console-template for more information



public record struct Ticket
{
    public string Title { get; init; }
    public DateTime Date { get; init; }
    public TimeSpan Time { get; init; }
}
