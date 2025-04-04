# List

This project contains two different implementations of a list. 

The first version was replaced by the second one during refactoring.  
The current list implementation can be found in the `MyList.cs` file and is covered by tests located in the `MyListTest.cs` file.

## Versions:
1. The first version is based on a circular linked list. 
   The development process for this version can be found in the branches `circular-linked-list` and `fix-circular-list`.

3. The second implementation is based on arrays.  
   Its development process can be found in the `array-based-list` branch.

## Methods

`MethodName (Parameters) => ReturnType` - description

- `Length () => int` - Returns the number of elements in the list.
- `Get (int index) => T` - Returns the element at the specified index. Throws an exception if the index is invalid.
- `Append (T value) => void` - Adds an element to the end of the list.
- `Insert (T value, int index) => void` - Inserts an element at the specified index. Throws an exception if the index out of bounds.
- `FindFirst (T value) => int` - Finds the first element with the given value and returns its index. Returns -1 if the value is not found.
- `FindLast (T value) => int` - Finds the last element with the given value and returns its index. Returns -1 if the value is not found.
- `Delete (int index) => T` - Deletes the element at the given index and returns it value. Throws an exception if the index out of bounds.
- `DeleteAll (T value) => void` - Deletes all elements equal to the given value from the list.
- `Clear () => void` - Removes all elements from the list.
- `ToArray () => T[]` - Returns a new array containing all elements of the list in order.
- `Reverse () => void` - Reverses the order of elements in the list.
- `Clone () => MyList<T>` - Returns a copy of the current list.
- `Extend (MyList<T> list) => void` - Adds all elements from another list to the current list.

## Installation and run

Make sure you have [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

1. Clone the repository:
    ```bash
    git clone https://github.com/Andrii-Detix/MTSD_lab2.git
    ```
    
2. Navigate to the project directory:
    ```bash
    cd MTSD_lab2
    ```

3. Run the project with a usage example:
    ```bash
    dotnet run --project MyList.App
    ```

4. Run tests:
    ```bash
    dotnet test MyList.Test
    ```
    
## Variant

Number in the group list: `8`.

`8 mod 4 = 0`

| Variant | First implementation | Second Implementation |
|---------|----------------------|-----------------------|
| 8       | Circular linked list | Array based list      |

## Commit with failed tests in CI/CD

During development, there was a commit where the tests failed in CI/CD. The test failure was caused by an incorrect implementation of the Extend method.

The commit can be found at the following [link](https://github.com/Andrii-Detix/MTSD_lab2/commit/ba063a6f44df2f66138fa8cb47eb3a990f5f82ea).

## Conclusions on the use of tests.

During the development of my custom list implementation, I wrote tests. To be honest, they really helped me quickly find places in the code that led to errors and incorrect results.

While I was writing the code for the first version with the circular linked list, I didn’t have tests. Therefore, after writing each function, it was difficult to check if everything worked correctly. However, after completing the first version of the list, I wrote tests for all methods and even discovered that one of the methods was incorrect and fixed it.

During the development of the second version of the list, I already had the tests. This allowed me to quickly verify whether the program was working correctly after using the new implementation.

By adding the CI/CD pipeline with GitHub Actions, I was also able to automatically check the program for tests as a result of pushes and pull requests.

So, I can conclude that tests provided me with only advantages, which made the refactoring and maintenance process easier. The only disadvantage is that writing tests takes time, but all the benefits outweigh this downside.

## Author

Developed by [Andrii Ivanchyshyn](https://github.com/Andrii-Detix/Sliding_Puzzle_Project/commits?author=Andrii-Detix).
