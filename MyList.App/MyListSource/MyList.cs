﻿using MyList.App.MyListSource.Exceptions;

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
        throw new Exception();
    }
    
    public int FindFirst(T value)
    {
        throw new Exception();
    }
    
    public int FindLast(T value)
    {
        throw new Exception();
    }
    
    public T Delete(int index)
    {
        throw new Exception();
    }
    
    public void DeleteAll(T value)
    {
        throw new Exception();
    }
    
    public void Clear()
    {
        throw new Exception();
    }
    
    public T[] ToArray()
    {
        throw new Exception();
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
    
    private bool IsFull()
    {
        return _size == _items.Length;
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
}