////ListOfInts list = new ListOfInts();
////list.Add(5);
////list.Add(6);
////list.Add(7);
////list.Add(8);
////list.RemoveAt(4);


//if("Anna".CompareTo("Smith") > 0)
//{
//    Console.WriteLine("Smith Anna");
//}
//else
//{
//    // something else
//}

//List<Pet> pets = new List<Pet>()
//{
//    new Pet(PetType.Dog, 10),
//    new Pet(PetType.Cat, 5),
//    new Pet(PetType.Fish, 0.9),
//    new Pet(PetType.Dog, 45),
//    new Pet(PetType.Cat, 2),
//    new Pet(PetType.Fish, 0.02),
//};
//DictExercise.FindMaxWeights(pets);

List<int> numbers = new List<int>() { 5, 1, 8, 11 };
List<int> nums = null;
var first = nums.First();

Console.ReadKey();


public static class DictExercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        Dictionary<PetType, List<double>> petGroups = new Dictionary<PetType, List<double>>();
        foreach (var pet in pets)
        {
            if (!petGroups.ContainsKey(pet.PetType))
            {
                petGroups[pet.PetType] = new List<double>();
            }
            petGroups[pet.PetType].Add(pet.Weight);
        }
        Dictionary<PetType, double> result = new Dictionary<PetType, double>();
        foreach (var petGroup in petGroups)
        {
            double maxWeight = petGroup.Value.Max();
            result.Add(petGroup.Key, maxWeight);
        }
        return result;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }





/// <summary>
/// ////////////////////////////////////////////////////////////
/// </summary>
//SortedList<FullName> list = new(
//    new List<FullName>()
//    {
//        new FullName(){ FirstName = "Anna", LastName = "Andrikson"},
//        new FullName(){ FirstName = "Will", LastName = "Watson"},
//        new FullName(){ FirstName = "Johannes", LastName = "Johannesov"},
//        new FullName(){ FirstName = "Benjamin", LastName = "Andrikson"},
//    });



public class SortedList<T> where T : IComparable<T>
{
    public IEnumerable<T> Items { get; }

    public SortedList(IEnumerable<T> items)
    {
        var asList = items.ToList();
        asList.Sort();
        Items = asList;
    }
}

public class FullName : IComparable<FullName>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public override string ToString() => $"{FirstName} {LastName}";

    public int CompareTo(FullName other)
    {
        if (LastName.CompareTo(other.LastName) > 0)
        {
            return 1;
        }
        else if (LastName.CompareTo(other.LastName) < 0)
        {
            return -1;
        }
        else
        {
            if (FirstName.CompareTo(other.FirstName) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}


/// <summary>
/// ////////////////////////////////////////////////////////////
/// </summary>
public class ListOfInts
{
    private int[] _items;
    private int _size;

    public ListOfInts()
    {
        _size = 0;
        _items = new int[4];
    }

    public void Add(int item)
    {
        if(_size == _items.Length)
        {
            // create new arr with double the size of old
            int[] itemsCopy = new int[_items.Length * 2];
            // copy from old to new
            for(int i = 0; i < _items.Length; i++)
            {
                itemsCopy[i] = _items[i];
            }
            // add
            itemsCopy[_size] = item;
            _items = itemsCopy;
        }
        else
        {
            _items[_size] = item;
        }
        _size++;
    }

    public int RemoveAt(int index)
    {
        int item;
        if(index < 0 || index > _items.Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        item = _items[index];
        for (int i = index; i < _items.Length - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _items[_items.Length - 1] = 0;
        _size--;
        return item;
    }
}