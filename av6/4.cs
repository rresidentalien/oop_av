Console.WriteLine(Filters.IsEven(3));

Filter filter = Filters.IsEven;

List<int> numbers = new List<int>() {-1, 1, 2, 3, 4, 5, 6};
Console.WriteLine(string.Join(",", numbers));

//genericki/gotovi delegat Func - vraca vrijednost
Func<int, bool> filter = Filters.IsEven; //moze predstaviti bilo koju funkciju koja prima int i vraca bool

var evenNumbers = ListUtilities.Filter(numbers, Filters.IsEven);
Console.WriteLine(string.Join(",", evenNumbers));
var positiveNumbers = ListUtilities.Filter(numbers, Filters.IsPositive);
Console.WriteLine(string.Join(",", positiveNumbers));

//genericki delegat Action - vraca void



public delegate bool Filter(int number);
public delegate bool MyFunc<T>(T number);



public static class Filters
{
    public static bool IsEven(int number) => number % 2 == 0;
    public static bool IsPositive(int number) => number > 0;
}

public static class ListUtilities
{
    public static List<T> Filter<T>(List<int> numbers, MyFunc<T> filter)
    {
        List<T> filteredNumbers = new List<T>();
        foreach(T number in numbers)
        {
            if(filter(number))
            {
                filteredNumbers.Add(number);
            }
        }

        return filteredNumbers;
    }

    public static List<int> Filter<T>(List<int> numbers, Func<T, bool> filter)
    {
        List<T> filteredNumbers = new List<T>();
        foreach(T number in numbers)
        {
            if(filter(number))
            {
                filteredNumbers.Add(number);
            }
        }

        return filteredNumbers;
    }
}