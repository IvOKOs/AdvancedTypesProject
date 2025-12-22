// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LinkedListCustom<string?> textLinkedList = new LinkedListCustom<string?>(null);
textLinkedList.AddToEnd("a");

foreach(var str in textLinkedList)
{
    Console.WriteLine(str);
}

Console.ReadKey();