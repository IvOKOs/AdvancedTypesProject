// See https://aka.ms/new-console-template for more information
using System.Collections;

public class LinkedListCustom<T> : ILinkedList<T>
{
    public Node<T?>? Head {  get; private set; }

    public LinkedListCustom(Node<T?>? head)
    {
        Head = head;
    }

    public int Count => GetCount();

    private int GetCount()
    {
        if(Head is null) return 0;
        int count = 0;
        var curr = Head;
        while(curr != null)
        {
            curr = curr.Next;
            count++;
        }
        return count;
    }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        AddToEnd(item);
    }

    public void AddToEnd(T item)
    {
        Node<T?> newNode = new Node<T?>(item, null);
        if(Head is null)
        {
            Head = newNode;
            return;
        }
        Node<T?>? currentNode = Head;
        while (currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }
        currentNode.Next = newNode;
    }

    public void AddToFront(T item)
    {
        Node<T?> newNode = new Node<T?>(item, null);

        var currHead = Head;
        Head = newNode;
        newNode.Next = currHead;
    }

    public void Clear()
    {
        Head = null;
    }

    public bool Contains(T item)
    {
        if (Head is null) return false;
        
        var curr = Head;
        while (curr != null)
        {
            if(curr.Data.Equals(item)) return true;
            curr = curr.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null || array.Length - arrayIndex < Count)
        {
            throw new ArgumentException();
        }
        if(arrayIndex < 0 || arrayIndex > array.Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        T?[] values = new T?[Count];
        int i = 0;
        var curr = Head;
        while(curr != null)
        {
            values[i] = curr.Data;
            i++;
            curr = curr.Next;
        }
        values.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        var curr = Head;
        while (curr != null)
        {
            yield return curr.Data!;
            curr = curr.Next;
        }
    }

    public bool Remove(T item)
    {
        var curr = Head;
        Node<T>? prev = null;

        if (curr is null) return false;
        if(curr.Next is null)
        {
            Clear();
            return true;
        }

        while(curr != null)
        {
            if(curr.Data.Equals(item))
            {
                break;
            }
            prev = curr;
            curr = curr.Next;
        }
        if(prev is null || curr is null) return false;
        prev.Next = curr.Next;
        return true;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
