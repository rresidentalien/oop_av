//LINQ
//KOPIRATI PRIMJER IZ AV S PIVOM

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