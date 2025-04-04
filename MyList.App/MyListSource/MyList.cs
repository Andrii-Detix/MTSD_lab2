using MyList.App.MyListSource.Exceptions;

namespace MyList.App.MyListSource;

public class MyList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public MyList(T value)
    {
        AddHeadIfNull(value);
    }

    public MyList()
    {
    }
    
    public int Length()
    {
        if (_head is null) return 0;
        
        int counter = 0;
        Node<T> current = _head!;

        do
        {
            counter++;
            current = current.Next!;
        } while (current != _head);

        return counter;
    }
    
    public T Get(int index)
    {
        if (index < 0 || _head is null) throw new IndexOfElementOutOfRangeException();

        int counter = 0;
        Node<T> current = _head;

        while (counter != index)
        {
            current = current.Next!;
            counter++;

            bool isCompletedLoop = current == _head && counter != 0;
            if (isCompletedLoop) throw new IndexOfElementOutOfRangeException();
        }

        return current.Value;
    }
    
    public void Append(T value)
    {
        if (_head is null)
        {
            AddHeadIfNull(value);
            return;
        }

        Node<T> node = new Node<T>(value, _head);
        Node<T> current = _head;

        while (current.Next != _head)
        {
            current = current.Next!;
        }

        current.SetNext(node);
        _tail = node;
    }
    
    public void Insert(T value, int index)
    {
        if (index < 0) throw new IndexOfElementOutOfRangeException();

        if (_head is null)
        {
            if (index != 0) throw new IndexOfElementOutOfRangeException();

            AddHeadIfNull(value);
            return;
        }

        int counter = 0;
        Node<T> current = _head!;
        Node<T> previous = _tail!;

        while (true)
        {
            bool isCompletedLoop = current == _head && counter != 0;
            
            if (counter == index)
            {
                Node<T> node = new Node<T>(value, current);
                previous.SetNext(node);

                if (counter == 0)
                {
                    _head = node;
                }
                else if (isCompletedLoop)
                {
                    _tail = node;
                }
                
                return;
            }
            
            if (isCompletedLoop) break;

            counter++;
            previous = current;
            current = current.Next!;
        }

        throw new IndexOfElementOutOfRangeException();
    }
    
    public int FindFirst(T value)
    {
        if (_head is null) return -1;

        int index = 0;
        Node<T> current = _head;

        while (!EqualityComparer<T>.Default.Equals(current.Value, value))
        {
            current = current.Next!;
            index++;

            bool isCompletedLoop = current == _head && index != 0;
            if (isCompletedLoop) return -1;
        }
        
        return index;
    }
    
    private void AddHeadIfNull(T value)
    {
        if (_head is not null) throw new HeadIsNotNullException();

        Node<T> node = new Node<T>(value);
        node.SetNext(node);

        _head = node;
        _tail = node;
    }
}