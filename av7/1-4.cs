//ne treba se rjesavati redom, ali moramo oznaciti broj zadatka
//ako nismo rjesili zadatak, prekriziti broj pitanja da prof ne trazi je li se izgubio papir
//ne prepisivati kod koji vec pise, ne mora se navoditi using



public class Company {
    string name;
    decimal yearlyEarnings;
    decimal stockValue;
}
public static void Run () {
    Company span = new Company ("SPAN", 105 _100_000m , 50.60m);
    Company ericsson = new Company (" Ericsson Nikola Tesla", 300 _000_000m , 61.66m);
    Company largest = span > ericsson ? span : ericsson ;
    Console.WriteLine ($"{ largest.Name}, revenue : { largest.YearlyEarnings }, stock: { largest.StockValue }");
 }
//1. zadatak - trebamo napraviti parametarski konstruktor, preoptereceni operator (samo onaj koji se koristi), svojstva
public Company(string name, decimal yearlyEarnings, decimal stockValue)
{
    this.name = name;
    this.yearlyEarnings = yearlyEarnings;
    this. stockValue = stockValue;
}

public string Name {get {return name; } }
public decimal YearlyEarnings { get {return yearlyEarnings; } }
public decimal StockValue { get {return stockValue; } }
//ovdje mozemo napraviti samo potpuno svojstvo, ne automatsko jer moramo koristiti vec postojece atribute

public static bool operator > (Company left, Company right)
{
    if(left.yearlyEarnings == right.yearlyEarnings) 
        return left.stockValue > right.stockValue;
    return left.yearlyEarnings > right.yearlyEarnings;
}
//operator < nije potrebno pisati na ispitu!





//2. zadatak
public string CreateAcronym() //ni slucajno ovdje napisati string name - odmah se ne priznaje cijeli zadatak
{
    string acronym = "";
    string[] words = name.Split(" ");
    if (words.Length >= 3)
    {
        for (int i = 0; i < 3; ++i)
        {
            acronym += words[i][0]; //ili words[i].First;
            //stringovi su kolekcije slova i podrzavaju indeksiranje
        }
    }
    else
    {
        for(int i = 0; i < name.Length; ++i)
        {
            if (nameof[i] != ' ')
            {
                acronym += name[i];
            }
            if (acronym.Length == 3)
            {
                break;
            }
        }
    }
    return acronym.ToUpper();
}
//ima puno nacina za rjesiti zadatak, ne gleda se implementacija nego je bitno da radi ono sto zadatak kaze





Dictionary <int , Company > yearlyReports = new Dictionary <int , Company >() {
    { 2012 , new Company (" Infinum ", 84 _000_105 , 35.44m) },
    { 2014 , new Company (" Infinum ", 91 _000_105 , 44.11m) },
    { 2016 , new Company (" Infinum ", 63 _000_105 , 22.27m) },
};
DrasticYears drasticYears = StockAnalyst . FindDrasticYears ( yearlyReports );
Console . WriteLine ($"Best: { drasticYears.BestYear }, worst: { drasticYears.WorstYear }.");
//3. zadatak
class DrasticYears
{
    public int BestYear {get; private set;}
    public int WorstYear {get; private set;}
}
static class StockAnalyst //nije bitno hocemo li stavljati public ili necemo, to se na ispitu ne gleda, ako bude greska s pravom pristupa nema veze
{
    public static DrasticYears FindDrasticYears(Dictionary<int, Company> reports)
    {
        int bestYear = reports.First().Key; //uzimamo kljuc prvog elementa rijecnika - kljuc je godina
        int worstYear = bestYear;

        foreach(var report in reports)
        {
            if (report.Value.StockValue < reports[worstYear].StockValue)
            {
                worstYear = report.Key;
            }
            if (report.Value.StockValue > reports[bestYear].StockValue)
            {
                bestYear = report.Key;
            }
        }
        return new DrasticYears(bestYear, wortsYear);
    }
}


//4. zadatak - greske
public class StockMarket {
    public string name;
    private List <Company > listedCompanies;

    public StockMarket(string name) {
        this.name = name;
    }
    public void GetName () { return this.name; }
    public void SetName ( string name) { name = this.name; }
    public static string GetAdBanner () { return $"Work with {name} for maximum profits !"; }
}
//  red 2 - string name mora biti private
//  red 5 - nedostaje inicijalizacija liste u konstruktoru - objekti moraju imati sve atribute spremne za rad
//  red 8 - metoda GetName ne moze biti void
//  red 9 - this.name = name umjesto obrnuto
//  red 10 - ne mozemo pristupati nestatickim clanovima klase u statickim metodama

//to sto neki atribut postoji, a ne koristi se, nije greska
//nekoliko zadataka cine jednu cjelinu zajedno, podijeljene su trokuticima
//ima djelomicno bodovanje zadatka, ali samo na cijele brojeve