﻿using MyList.App.MyListSource.Exceptions;

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
    
    private void AddHeadIfNull(T value)
    {
        if (_head is not null) throw new HeadIsNotNullException();

        Node<T> node = new Node<T>(value);
        node.SetNext(node);

        _head = node;
        _tail = node;
    }
}