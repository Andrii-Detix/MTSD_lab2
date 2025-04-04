using FluentAssertions;
using MyList.App.MyListSource;
using MyList.App.MyListSource.Exceptions;

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
    
    [Fact]
    public void Get_Should_ReturnCorrectValue_When_IndexIsValid()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');

        list.Get(0).Should().Be('a');
        list.Get(1).Should().Be('b');
        list.Get(2).Should().Be('c');
    }

    [Fact]
    public void Get_Should_ThrowIndexofElementOutOfRangeException_When_IndexIsHigherThanMaximal()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');

        Action getWithIndexHigherThanMaximal = () => list.Get(4);

        getWithIndexHigherThanMaximal.Should().Throw<IndexOfElementOutOfRangeException>();
    }

    [Fact]
    public void Get_Should_ThrowIndexofElementOutOfRangeException_When_IndexIsLowerThanZero()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');

        Action getWithIndexLowerThanZero = () => list.Get(4);

        getWithIndexLowerThanZero.Should().Throw<IndexOfElementOutOfRangeException>();
    }
}