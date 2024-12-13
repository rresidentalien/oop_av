List<int> numbers = new List<int>() {-1, 1, 2, 3, 4, 5, 6};
Console.WriteLine(string.Join(",", numbers));

//sto cemo napraviti ako zelimo brzinski isfiltrirati listu?
Func<int, bool> filter = (int number) => number < 0; //anonimna funkcija / lambda izraz - treba mi samo jednom na brzinu neka funkcija i ne zelim ju pisati cijelu - obicno one liner, ali moze biti i vise redova i zadnji red koji se evaluira ce biti rezultat lambde, ali onda vrijedi to izdvojiti u metodu
var negativeNumbers = ListUtilities.Filter(numbers, filter);
Console.WriteLine(string.Join(",", negativeNumbers));

//drugi nacin:
var negativeNumbers = ListUtilities.Filter(numbers, number => number < 0); //funkcija koja postoji samo ovdje

var evenNumbers = numbers.Filter(it => it % 2 == 0);


public delegate bool Filter(int number);

public static class Filters
{
    public static bool IsEven(int number) => number % 2 == 0;
    public static bool IsPositive(int number) => number > 0;
}

public static class ListExtensions
{
    public static List<T> Filter<T>(this List<int> numbers, Func<T, bool> filter)
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

