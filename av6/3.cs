List<int> numbers = new List<int>() {1, 2, 3, 4, 5, 6};
IFilter filter = new EvenFilter();
Console.WriteLine(string.Join(",", numbers));
evenNumbers = ArrayUtilities.Filter(numbers, filter);
Console.WriteLine(string.Join(",", evenNumbers));

//kako bismo napravili filtriranje liste ali s razlicitim filterima?
interface IFilter
{
    bool IsValid(int number);
}

class EvenFilter : IFilter
{
    public bool IsValid(int number) => number % 2 == 0;
}

static class ArrayUtilities
{
    public static List<int> Filter(List<int> numbers, IFilter filter)
    {
        List<int> filteredNumbers = new List<int>();
        foreach(int number in numbers)
        {
            if(filter.IsValid(number))
            {
                filteredNumbers.Add(number);
            }
        }
    }
}

//ovaj nacin je okej, ali postoji drugi nacin
//ovako smo radili IFilter sa samo jednim filterom i jednom funkcijom
//bilo bi zgodnije da mozemo funkciju poslati kao argument drugoj funkciji
//=> DELEGAT
//bilo koju funkciju predstavljamo nekim delegatom
//samo opisujemo funkciju kakvu zelimo - tip i parametri
//delegat je zamjena za funkciju
//mozemo ovdje koristiti generic

Console.WriteLine(Filters.IsEven(3)); //netko je u moje ime pozvao funkciju

Filter filter = Filters.IsEven; //varijabla tipa Filter koju predstavlja delegat

List<int> numbers = new List<int>() {-1, 1, 2, 3, 4, 5, 6};
Console.WriteLine(string.Join(",", numbers));
Filter filter = Filters.IsEven;
var evenNumbers = ListUtilities.Filter(numbers, Filters.IsEven);
Console.WriteLine(string.Join(",", evenNumbers));
//napravili smo istu stvar, ali s delegatom
var positiveNumbers = ListUtilities.Filter(numbers, Filters.IsPositive);
Console.WriteLine(string.Join(",", positiveNumbers));



//after main (nista dobro se ne dogadja nakon maina????)
public delegate bool Filter(int number);

public static class Filters
{
    public static bool IsEven(int number) => number % 2 == 0;
    public static bool IsPositive(int number) => number > 0;
}

public static class ListUtilities
{
    public static List<int> Filter(List<int> numbers, Filter filter)
    {
        List<int> filteredNumbers = new List<int>();
        foreach(int number in numbers)
        {
            if(filter.Invoke(number)) //filter(number) je cisce i jasnije
            {
                filteredNumbers.Add(number);
            }
        }

        return filteredNumbers;
    }
}

//napravili smo istu stvar kao i ranije sa suceljima
//kada sucelje ima jednu jedinu metodu i uvodimo ju samo iz tog razloga bolje je koristiti delegat
//funkcije viseg reda - poslat cu ti neku funkciju nekog tipa 
//delegat poziva funkciju koju predstavlja