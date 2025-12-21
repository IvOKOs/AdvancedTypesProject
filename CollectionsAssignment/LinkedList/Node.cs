// See https://aka.ms/new-console-template for more information
public class Node<T>
{
    private T? _data;
    private Node<T?>? _next;

    public Node<T?>? Next { get { return _next; } set { _next = value; } }
    public T? Data { get { return _data; } }

    public Node(T? data, Node<T?>? next)
    {
        _data = data;
        _next = next;
    }
}
