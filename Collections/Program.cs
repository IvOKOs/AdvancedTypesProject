// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Utilities;

var customCollection = new CustomCollection(["aaa", "bbb"]);

//foreach(var word in customCollection)
//{
//    Console.WriteLine(word);
//}

//var dict = new Dictionary<int, string>() { [0] = "a" };
//var readonlyDict = new ReadOnlyDictionary<int, string>(dict);

//var nums = new int[] { 1, 2, 3, 6, 9, 16, 17 };
//var searchAlgos = new SearchAlgorithm();
//var index = searchAlgos.BinarySearch(nums, 8);

//var stack = new Stack<string>();

//stack.Push("cow");
//stack.Push("blouse");
//stack.Push("fart");

//var doesContain = stack.DoesContainAny(["bow", "mouse"]);

//var nums = GenerateEvenNums().Take(3);
//var nums1000 = GenerateEvenNums1000();

var items = new string?[] { "a", "b", null, "d", "e", "f" };
//var numsBeforeNegative = GetBeforeFirstNegative(nums);
//foreach (var num in numsBeforeNegative)
//{
//    Console.WriteLine(num);
//}
var itemsReversed = GetAllAfterLastNullReversed(items); // {"f", "e", "d"}

var itemsOnNewLine = items.AsNewLine();
Console.WriteLine(itemsOnNewLine);

Console.ReadKey();


static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
{
    for(int i = input.Count - 1; i >= 0; i--)
    {
        if(input[i] == null)
        {
            yield break;
        }
        yield return input[i];
    }
}

IEnumerable<int> GetBeforeFirstNegative(IEnumerable<int> input)
{
    List<int> res = new List<int>();
    foreach(var num in input)
    {
        if(num < 0)
        {
            break;
        }
        res.Add(num);
        yield return num;
    }
}


static IEnumerable<int> GenerateEvenNums()
{
    for(int i = 0; i < int.MaxValue; i += 2)
    {
        yield return i;
    }
}

static IEnumerable<int> GenerateEvenNums1000()
{
    var res = new List<int>();
    for(int i = 0; i < int.MaxValue; i += 2)
    {
        res.Add(i);
    }
    return res;
}

public static class StackExtensions
{
    public static bool DoesContainAny(this Stack<string> stack, params string[] input)
    {
        bool isItem = true;
        while (isItem)
        {
            isItem = stack.TryPop(out string? poppedItem);
            if (isItem && input.Contains(poppedItem)) return true;
        }
        return false;
    }
}



public class HashSetAlgos
{
    public static HashSet<T> CreateUnion<T>(
            HashSet<T> set1, HashSet<T> set2)
    {
        HashSet<T> res = new HashSet<T>();
        foreach(var item in set1)
        {
            res.Add(item);
        }
        foreach(var item in set2)
        {
            res.Add(item);
        }
        return res;
    }
}



public class SearchAlgorithm
{
    public int BinarySearch(int[] numbers, int targetNum)
    {
        if(numbers is null || numbers.Length == 0)
        {
            throw new ArgumentException($"{nameof(numbers)} is not in correct format.");
        }

        int leftBound = 0;
        int rightBound = numbers.Length - 1;

        while(rightBound >= leftBound)
        {
            int middleIndex = (leftBound + rightBound) / 2;
            if (numbers[middleIndex] == targetNum) return middleIndex;
            if (numbers[middleIndex] < targetNum)
            {
                leftBound = middleIndex + 1;
            }
            else
            {
                rightBound = middleIndex - 1;
            }
        }
        return -1;
    }
}




public class CustomCollection : IEnumerable<string>
{
    string[] Words { get; }
    public CustomCollection(string[] words)
    {
        Words = words;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }

    public IEnumerator<string> GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class WordsEnumerator : IEnumerator<string>
{
    private const int InitialIndex = -1;
    private int _currIndex = InitialIndex;
    private readonly string[] _words;

    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    object IEnumerator.Current => Current;

    public string Current
    {
        get
        {
            try
            {
                return _words[_currIndex];
            }
            catch(IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(Current)} is out of range for this collection.", ex);
            }
        }
    }

    public bool MoveNext()
    {
        if(_currIndex >= _words.Length - 1)
        {
            return false;
        }
        _currIndex++;
        return true;
    }

    public void Reset()
    {
        _currIndex = InitialIndex;
    }

    public void Dispose()
    {
        
    }
}
