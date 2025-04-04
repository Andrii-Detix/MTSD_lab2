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
    
    [Fact]
    public void DeleteAll_Should_DeleteAllElementsWithGivenValue()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'a', 'b', 'c', 'a');

        list.DeleteAll('a');

        list.Length().Should().Be(3);
        list.FindFirst('a').Should().Be(-1);
        list.Get(0).Should().Be('b');
        list.Get(1).Should().Be('b');
        list.Get(2).Should().Be('c');


        list.DeleteAll('b');
        list.DeleteAll('c');

        list.Length().Should().Be(0);
        list.FindFirst('b').Should().Be(-1);
        list.FindLast('c').Should().Be(-1);
    }

    [Fact]
    public void Clear_Should_ClearListOfElements()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'a', 'b', 'c', 'a');

        list.Clear();

        list.Length().Should().Be(0);
        list.FindFirst('a').Should().Be(-1);
        list.FindLast('b').Should().Be(-1);
        list.FindFirst('c').Should().Be(-1);
    }
    
    [Fact]
    public void Reverse_Should_ReverseElementsInList_When_ListHasEvenNumberOfElements()
    {
        MyList<char> list = new MyList<char>('1', '2', '3', '4');

        list.Reverse();

        list.Length().Should().Be(4);
        list.Get(0).Should().Be('4');
        list.Get(1).Should().Be('3');
        list.Get(2).Should().Be('2');
        list.Get(3).Should().Be('1');
    }

    [Fact]
    public void Reverse_Should_ReverseElementsInList_When_ListHasOddNumberOfElements()
    {
        MyList<char> list = new MyList<char>('1', '2', '3');
        
        list.Reverse();
        
        list.Length().Should().Be(3);
        list.Get(0).Should().Be('3');
        list.Get(1).Should().Be('2');
        list.Get(2).Should().Be('1');
    }
    
    [Fact]
    public void ToArray_Should_ReturnListConvertedToArray()
    {
        MyList<char> list = new MyList<char>('a', 'b','c');
        
        char[] array = list.ToArray();
        
        array.Should().BeEquivalentTo(['a', 'b', 'c']);
    }

    [Fact]
    public void ToArray_Should_ReturnEmptyArray_When_ListIsEmpty()
    {
        MyList<char> list = new MyList<char>();
        
        char[] array = list.ToArray();

        array.Should().BeEmpty();
    }
    
        [Fact]
    public void Clone_Should_ReturnCloneOfListOfElements()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b', 'c');

        MyList<char> cloned = list.Clone();

        cloned.Length().Should().Be(list.Length());
        cloned.Get(0).Should().Be(list.Get(0));
        cloned.Get(1).Should().Be(list.Get(1));
        cloned.Get(2).Should().Be(list.Get(2));
        cloned.Get(3).Should().Be(list.Get(3));
    }

    [Fact]
    public void Clone_Should_Not_ClonedListEffectOriginalOne()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b');

        MyList<char> cloned = list.Clone();
        cloned.DeleteAll('a');
        cloned.Append('d');

        cloned.Length().Should().Be(2);
        cloned.Get(0).Should().Be('b');
        cloned.Get(1).Should().Be('d');
        list.Length().Should().Be(3);
        list.Get(0).Should().Be('a');
        list.Get(1).Should().Be('a');
        list.Get(2).Should().Be('b');
    }

    [Fact]
    public void Clone_Should_Not_OriginalListEffectClonedOne()
    {
        MyList<char> list = new MyList<char>('a', 'a', 'b');

        MyList<char> cloned = list.Clone();
        list.DeleteAll('a');
        list.Append('d');

        list.Length().Should().Be(2);
        list.Get(0).Should().Be('b');
        list.Get(1).Should().Be('d');
        cloned.Length().Should().Be(3);
        cloned.Get(0).Should().Be('a');
        cloned.Get(1).Should().Be('a');
        cloned.Get(2).Should().Be('b');
    }

    [Fact]
    public void Extend_Should_AddElementsToFirstListFromSecondOne()
    {
        MyList<char> first = new MyList<char>('a', 'b');
        MyList<char> second = new MyList<char>('c');

        first.Extend(second);

        first.Length().Should().Be(3);
        first.Get(0).Should().Be('a');
        first.Get(1).Should().Be('b');
        first.Get(2).Should().Be('c');
    }

    [Fact]
    public void Extend_Should_AddElementsToFirstListFromSecond_When_FirstListIsEmpty()
    {
        MyList<char> first = new MyList<char>();
        MyList<char> second = new MyList<char>('a', 'b');

        first.Extend(second);

        first.Length().Should().Be(2);
        first.Get(0).Should().Be('a');
        first.Get(1).Should().Be('b');
    }

    [Fact]
    public void Extend_Should_FirstListStayUnchanged_When_SecondListIsEmpty()
    {
        MyList<char> first = new MyList<char>('a', 'b');
        MyList<char> second = new MyList<char>();

        first.Extend(second);
        Action getElementFromFirstListByIndexTwo = () => first.Get(2);

        first.Length().Should().Be(2);
        first.Get(0).Should().Be('a');
        first.Get(1).Should().Be('b');
        getElementFromFirstListByIndexTwo.Should().Throw<IndexOfElementOutOfRangeException>();
    }

    [Fact]
    public void Extend_Should_Not_ExtendedListEffectOriginalOne()
    {
        MyList<char> first = new MyList<char>('a');
        MyList<char> second = new MyList<char>('b');

        first.Extend(second);
        first.Delete(0);
        first.Append('c');
        first.Append('c');
        Action getElementFromSecondListByIndexThree = () => second.Get(3);

        first.Length().Should().Be(3);
        first.Get(0).Should().Be('b');
        first.Get(1).Should().Be('c');
        first.Get(2).Should().Be('c');
        second.Length().Should().Be(1);
        second.Get(0).Should().Be('b');
        getElementFromSecondListByIndexThree.Should().Throw<IndexOfElementOutOfRangeException>();
    }

    [Fact]
    public void Extend_Should_Not_SecondListEffectExtendedOne()
    {
        MyList<char> first = new MyList<char>('a');
        MyList<char> second = new MyList<char>('b');

        first.Extend(second);
        second.Delete(0);
        second.Append('c');
        second.Append('c');
        Action getElementFromFirstListByIndexTwo = () => first.Get(2);

        first.Length().Should().Be(2);
        first.Get(0).Should().Be('a');
        first.Get(1).Should().Be('b');
        second.Length().Should().Be(2);
        second.Get(0).Should().Be('c');
        second.Get(1).Should().Be('c');
        getElementFromFirstListByIndexTwo.Should().Throw<IndexOfElementOutOfRangeException>();
    }
}