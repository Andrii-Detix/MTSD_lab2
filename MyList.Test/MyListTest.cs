using FluentAssertions;
using MyList.App.MyListSource;

namespace MyList.Test;

public class MyListTest
{
    [Fact]
    public void Length_Should_BeZero_When_CreateEmptyList()
    {
        MyList<char> list = new MyList<char>();

        list.Length().Should().Be(0);
    }

    [Fact]
    public void Length_Should_BeOne_When_CreateListWithOneElement()
    {
        MyList<char> list = new MyList<char>('a');

        list.Length().Should().Be(1);
    }

    [Fact]
    public void Length_Should_BeCorrect_When_AddSomeElements()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');

        list.Length().Should().Be(3);
    }
}