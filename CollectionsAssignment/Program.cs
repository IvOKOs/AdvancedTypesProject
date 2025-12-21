// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LinkedListCustom<string?> textLinkedList = new LinkedListCustom<string?>(new Node<string?>("a",
                                                                                 new Node<string?>("b", null)));
textLinkedList.Add("c");
textLinkedList.AddToFront("A");
textLinkedList.Count();
textLinkedList.Contains("c");
textLinkedList.Remove("c");

var arr = new string[] { "1", "2", "3", "4", "5", "6", "7" };
textLinkedList.CopyTo(arr, 2);

foreach(var str in textLinkedList)
{
    Console.WriteLine(str);
}

Console.ReadKey();