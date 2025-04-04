using MyList.App.MyListSource.Exceptions;

namespace MyList.App.MyListSource;

public class MyList<T>
{
    private const int DefaultCapacity = 4;

    private T[] _items = new T[DefaultCapacity];
    private int _size = 0;
    
    public MyList(params T[] values)
    {
        _items = values;
        _size = values.Length;
    }

    public MyList()
    {
    }
    
    public int Length()
    {
        return _size;
    }
    
    public T Get(int index)
    {
        if (index < 0 || index >= _size) throw new IndexOfElementOutOfRangeException();

        return _items[index];
    }
    
    public void Append(T value)
    {
        TryIncreaseCapacity();

        _items[_size] = value;
        _size++;
    }
    
    public void Insert(T value, int index)
    {
        if (index < 0 || index > _size) throw new IndexOfElementOutOfRangeException();

        TryIncreaseCapacity();

        for (int i = _size - 1; i >= index; i--)
        {
            _items[i + 1] = _items[i];
        }

        _items[index] = value;
        _size++;
    }
    
    public int FindFirst(T value)
    {
        for (int i = 0; i < _size; i++)
        {
            T item = _items[i];

            if (EqualityComparer<T>.Default.Equals(item, value))
            {
                return i;
            }
        }

        return -1;
    }
    
    public int FindLast(T value)
    {
        for (int i = _size - 1; i >= 0; i--)
        {
            T item = _items[i];

            if (EqualityComparer<T>.Default.Equals(item, value))
            {
                return i;
            }
        }

        return -1;
    }
    
    public T Delete(int index)
    {
        if (index < 0 || index >= _size) throw new IndexOfElementOutOfRangeException();

        T item = _items[index];

        for (int i = index; i < _size - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size - 1] = default!;

        _size--;
        
        TryReduceCapacity();
        
        return item;
    }
    
    public void DeleteAll(T value)
    {
        int counter = 0;
        int freeIndex = 0;

        for (int i = 0; i < _size; i++)
        {
            T item = _items[i];

            if (EqualityComparer<T>.Default.Equals(item, value))
            {
                counter++;
                continue;
            }

            if (i > freeIndex)
            {
                _items[freeIndex] = item;
            }

            freeIndex++;
        }

        ClearArray(freeIndex, counter);
        _size -= counter;
        
        TryReduceCapacity();
    }
    
    public void Clear()
    {
        _size = 0;
        _items = new T[DefaultCapacity];
    }
    
    public T[] ToArray()
    {
        T[] array = new T[_size];

        for (int i = 0; i < _size; i++)
        {
            array[i] = _items[i];
        }

        return array;
    }
    
    public void Reverse()
    {
        throw new Exception();
    }
    
    public MyList<T> Clone()
    {
        throw new Exception();
    }
    
    public void Extend(MyList<T> list)
    {
        throw new Exception();
    }
    
    private void TryIncreaseCapacity()
    {
        if (IsFull())
        {
            int capacity = _size * 2;
            ChangeCapacity(capacity);
        }
    }
    
    private void TryReduceCapacity()
    {
        if (IsSizeSmallerThanQuarterOfCapacity())
        {
            int newCapacity = _size * 2;
            ChangeCapacity(newCapacity);
        }
    }
    
    private bool IsFull()
    {
        return _size == _items.Length;
    }
    
    private bool IsSizeSmallerThanQuarterOfCapacity()
    {
        return _size < _items.Length / 4;
    }
    
    private void ChangeCapacity(int capacity)
    {
        if (capacity < _size) return;
        
        T[] newItems = new T[capacity];

        for (int i = 0; i < _size; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
    }
    
    private void ClearArray(int startIndex, int length)
    {
        int limit = startIndex + length;

        for (int i = startIndex; i < limit && i < _items.Length; i++)
        {
            _items[i] = default!;
        }
    }
}