namespace MyList.App.MyListSource;

public class Node<T>
{
    public Node(T value, Node<T>? next = null)
    {
        Next = next;
        Value = value;
    }

    public T Value { get; }
    public Node<T>? Next { get; private set; }

    public void SetNext(Node<T> next)
    {
        Next = next;
    }
}