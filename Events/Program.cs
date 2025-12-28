const int threshold = 30_000;

GoldPriceReader goldPriceReader = new GoldPriceReader();
EmailPriceChangeNotifier emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);
PushPriceChangeNotifier pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);
goldPriceReader.PriceRead += emailPriceChangeNotifier.Update;
goldPriceReader.PriceRead += pushPriceChangeNotifier.Update;
goldPriceReader.PriceRead -= pushPriceChangeNotifier.Update;

for(int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrPrice();
}

Console.ReadKey();



public delegate void PriceRead(decimal price);

public class GoldPriceReader
{// observable - class that is being observed by other classes and sends data to them
    private int _currGoldPrice;
    //private readonly List<IObserver<decimal>> _observers = new List<IObserver<decimal>>();

    public event PriceRead? PriceRead;
    
    public void ReadCurrPrice()
    {
        _currGoldPrice = new Random().Next(20_000, 50_000);
        OnPriceRead(_currGoldPrice);
    }

    private void OnPriceRead(decimal price)
    {
        PriceRead?.Invoke(price);
    }
}


public class EmailPriceChangeNotifier
{// observer - observes for changes
    private readonly decimal _threshold;

    public EmailPriceChangeNotifier(decimal threshold)
    {
        _threshold = threshold;
    }

    public void Update(decimal amount)
    {
        if(amount > _threshold)
        {
            Console.WriteLine("Sending email");
        }
    }
}

public class PushPriceChangeNotifier
{
    private readonly decimal _threshold;

    public PushPriceChangeNotifier(decimal threshold)
    {
        _threshold = threshold;
    }

    public void Update(decimal amount)
    {
        if (amount > _threshold)
        {
            Console.WriteLine("Sending push");
        }
    }
}

public interface IObserver<T>
{
    void Update(T data);
}

public interface IObservable<T>
{
    void AttachObserver(IObserver<T> observer);
    void DetachObserver(IObserver<T> observer);
    void Notify();
}
