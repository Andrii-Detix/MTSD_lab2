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
    
    [Fact]
    public void Append_Should_AddElementToTheEndOfList()
    {
        MyList<char> list = new MyList<char>();

        list.Append('a');
        list.Append('b');
        list.Append('c');

        list.Length().Should().Be(3);
        list.Get(0).Should().Be('a');
        list.Get(1).Should().Be('b');
        list.Get(2).Should().Be('c');
    }

    [Fact]
    public void Insert_Should_AddElementByTheGivenIndex_When_IndexIsValid()
    {
        MyList<char> list = new MyList<char>('a', 'b');

        list.Insert('1', 0);
        list.Insert('2', 1);
        list.Insert('4', 4);

        list.Length().Should().Be(5);
        list.Get(0).Should().Be('1');
        list.Get(1).Should().Be('2');
        list.Get(2).Should().Be('a');
        list.Get(3).Should().Be('b');
        list.Get(4).Should().Be('4');
    }

    [Fact]
    public void Insert_Should_ThrowIndexOfElementOutOfRangeException_When_IndexIsInvalid()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');

        Action insertByIndexHigherThanSizeOfList = () => list.Insert('!', 5);
        Action insertByIndexLowerThanZero = () => list.Insert('1', -1);

        insertByIndexHigherThanSizeOfList.Should().Throw<IndexOfElementOutOfRangeException>();
        insertByIndexLowerThanZero.Should().Throw<IndexOfElementOutOfRangeException>();
    }
    
    
    [Fact]
    public void Delete_Should_DeleteElementFromTheListByIndexAndReturnValue_When_IndexIsValid()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');


        char deleted = list.Delete(1);

        deleted.Should().Be('b');
        list.Length().Should().Be(2);
        list.Get(0).Should().Be('a');
        list.Get(1).Should().Be('c');


        deleted = list.Delete(1);

        deleted.Should().Be('c');
        list.Length().Should().Be(1);
        list.Get(0).Should().Be('a');


        deleted = list.Delete(0);

        deleted.Should().Be('a');
        list.Length().Should().Be(0);
    }

    [Fact]
    public void Delete_Should_ThrowIndexofElementOutOfRangeException_When_IndexIsInvalid()
    {
        MyList<char> list = new MyList<char>('a', 'b', 'c');

        Action deleteByIndexHigherThanSizeOfList = () => list.Delete(5);
        Action deleteByIndexLowerThanZero = () => list.Delete(-1);

        deleteByIndexHigherThanSizeOfList.Should().Throw<IndexOfElementOutOfRangeException>();
        deleteByIndexLowerThanZero.Should().Throw<IndexOfElementOutOfRangeException>();
    }

    [Fact]
    public void FindFirst_Should_ReturnIndexOfFirstElementWithGivenValue_When_ListHasElement()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'a', 'b', 'c', 'a');

        list.FindFirst('a').Should().Be(0);
        list.FindFirst('b').Should().Be(2);
        list.FindFirst('c').Should().Be(5);
    }

    [Fact]
    public void FindFirst_Should_ReturnMinusOne_When_ListHasNotElementWithGivenValue()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'a', 'b', 'c', 'a');

        list.FindFirst('1').Should().Be(-1);
    }

    [Fact]
    public void FindLast_Should_ReturnLastElementWithGivenValue_When_ListHasElement()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'a', 'b', 'c', 'a');

        list.FindLast('a').Should().Be(6);
        list.FindLast('b').Should().Be(4);
        list.FindLast('c').Should().Be(5);
    }

    [Fact]
    public void FindLast_Should_ReturnMinusOne_When_ListHasNotElementWithGivenValue()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'a', 'b', 'c', 'a');

        list.FindFirst('1').Should().Be(-1);
    }
}