using MyList.App.MyListSource;

// Example of usage

MyList<char> list = new MyList<char>('a', 'b');

int length = list.Length();
Console.WriteLine($"Length: {length}");

char firstElement = list.Get(0);
Console.WriteLine($"First element: {firstElement}");

list.Append('c');
list.Append(firstElement);

list.Insert('c', 1);

char deleted = list.Delete(0);
Console.WriteLine($"Deleted: {deleted}");

int firstc = list.FindFirst('c');
int lastc = list.FindLast('c');

Console.WriteLine($"First index of 'c': {firstc}\nLast index of 'c': {lastc}");

list.DeleteAll('c');
int newFirstc = list.FindFirst('c');
Console.WriteLine($"New first index of 'c': {newFirstc}");

list.Clear();
length = list.Length();
Console.WriteLine($"Length after clear: {length}");

MyList<char> list2 = new MyList<char>('l', 'o', 'l');
MyList<char> cloned = list2.Clone();

cloned.Extend(list2);

char[] array = cloned.ToArray();
foreach (char item in array)
{
    Console.WriteLine($"item: {item}");
}

try
{
    list2.Clear();
    list2.Get(5);
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.Message}");
}
