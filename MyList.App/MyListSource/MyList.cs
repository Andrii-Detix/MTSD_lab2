namespace MyList.App.MyListSource;

public class MyList<T>
{
    private const int DefaultCapacity = 4;

    private T[] items = new T[DefaultCapacity];
    private int size = 0;
    
    public MyList(params T[] values)
    {
        items = values;
        size = values.Length;
    }

    public MyList()
    {
        
    }
    
    public int Length()
    {
        throw new Exception();
    }
    
    public T Get(int index)
    {
        throw new Exception();
    }
    
    public void Append(T value)
    {
        throw new Exception();
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
}