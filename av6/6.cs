//LINQ
//iz av dokumenta primjer 3.1
public class Beer : IEquatable<Beer>
{
    public string Name { get; private set; }
    public string Brewery { get; private set; }
    public string Country { get; private set; }
    public double AlcoholPercent { get; private set; }

    public Beer(string brewery, string name, string country, double alcoholPercent)
    {
        Name = name;
        Country = country;
        AlcoholPercent = alcoholPercent;
        Brewery = brewery;
    }

    public override string ToString() => $"{Brewery},{Country},{Name},{AlcoholPercent}";
    public override int GetHashCode() => HashCode.Combine(Brewery, Name, AlcoholPercent, Country);

    public override bool Equals(object obj)
    {
        if (obj is Beer == false) return false;
        return this.Equals((Beer)obj);
    }

    public bool Equals(Beer other)
    {
        return Name == other.Name &&
                Brewery == other.Brewery &&
                AlcoholPercent == other.AlcoholPercent &&
                Country == other.Country;
    }
}

public class NetworkingUtilities
{
    public static List<Beer> GetBeerFromApi()
    {
        return new List<Beer>()
        {
        new Beer("Zmajska pivovara", "Pale ale", "HR", 5.3),
        new Beer("The garden brewery", "Citrus india pale ale", "HR", 7.2),
        new Beer("Nova runda", "Fireball pale ale", "HR", 6.2),
        new Beer("The garden brewery", "Stout", "HR", 5.7),
        new Beer("LAB Split", "Barba pale ale", "HR", 5.2),
        new Beer("Nova runda", "American pale ale", "HR", 5.2),
        new Beer("Zmajska pivovara", "Dragonfish tripel", "HR", 8.9),
        new Beer("Nova runda", "Hladovina session india pale ale", "HR", 5.0),
        new Beer("Bernard", "Bernard celebration lager", "CZ", 4.9),
        new Beer("Bernard", "Bernard jantarovy lezak", "CZ", 4.7),
        new Beer("Brasserie D’achouffe", "Le chouffe", "BE", 8.0),
        new Beer("Duvel", "Duvel", "BE", 8.5),
        };
    }
}

public class Utilities
{
    public static string GetAsStringRows<T>(IEnumerable<T> data)
    {
        return string.Join(Environment.NewLine, data);
    }
}

// IEQuatable - implementiramo metodu Equals
//savjet - uvijek koristiti HashCode.Combine kako bi se on racunao na temelju vrijednosti atributa - izbjegavamo situaciju da dopusta dva ista objekta na razlicitim adresama

//programmable web - stranica s javno dostupnim api-ima - jako zgodna stvar - ako ne znamo sto bismo radili

//mi u primjeru imamo fake api

var beers = NetworkingUtilities.GetBeerFromApi();
Console.WriteLine(Utilities.GetAsStringRows(beers));

//savjet - preskociti query sintaksu (ne treba nam sada i postoji samo u C#)

//operatori filtriranja - take ili skip
var belgianBeers = beers.Where(beer => beer.Country == "BE"); //func iz int u bool = predikat

//mozemo imati dva ili vise uvjeta - dodajemo znak &&

//Where je najcesci, ali ima ih jos i koristit cemo ih jos - first, last, take, skip
//Where - vraca isti tip s manjim ili jednakim brojem podataka s kojim smo poceli

var breweries = beers.Select(beer => beer.Brewery).Distinct().OrderBy(it => it); //preslikavanje - iz piva preslikaj u pivovaru, uzmi samo jedinstvene i poredaj
Console.WriteLine(Utilities.GetAsStringRows(breweries));