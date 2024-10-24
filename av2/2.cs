namespace av2;
class Program
{
    static void Main(string[] args)
    {
        Complex c1 = new Complex(3, 9); 
        Console.WriteLine(c1.GetAsString());

        Complex c2 = new Complex(7); 
        Console.WriteLine(c2.GetAsString());

        Army croArmy = neww Army(35);
        Army usaArmy = new Army(36);

        Console.WriteLine(croArmy.GetSoldierCost());
        Console.WriteLine(usaArmy.GetSoldierCost());
        croArmy.IncreaseSoldierCost();
        Console.WriteLine(usaArmy.GetSoldierCost()); //dobit cemo 11 iako smo napisali croArmy jer je GetSoldierCost static i time se mijenja "globalno"
        //zato izbjegavati static ako nam nije apsolutno nuzno

        Army mercenaries = Army.Hire(99);
        Army recruits = Army.Recruit(1000);
    }
}

//ne smijemo dio pisati u inicijalizatoru, a dio u konstruktoru - ako pisemo konstruktor onda stavimo sve u njega
class Complex
{ 
    public int Real { get; private set; } //automatsko svojstvo
    //compiler kreira pristupne metode u koje mi nemamo uvid
    //mozemo pozvati get izvan klase, ali ne i set - set samo unutar klase

    public int Imaginary { get; private set; }

    //delegirani konstruktor = 
    
    //duplicirani kod - dolje imamo isto to
    /*public Complex(int real, int imaginary)
    {
        this.Real = 0;
        this.Imaginary = 0;
    }*/


    public Complex() : this(0, 0) {}
    public Complex(int real, int imaginary)
    {
        this.Real = real;
        this.Imaginary = imaginary;
    }
    public string GetAsString()
    {
        string sign = Imaginary < 0 ? "" : "+";
        return $"{Real}{sign}{Imaginary}i" //radimo novi string na temelju manjih
        //na Real i Imaginary se radi automatska konverzija u string iz int
    }

    //metodima ili atributima koji su static pristupamo preko klase, ne objekta
    //i dalje se koristi . ali se navodi ime klase
    //zato kazemo da se static elementi pristupaju na klasi
    //ne-static elementi su na instanci(objektu)
    //ovo koristimo kad nam nije nuzno da svaki objekt ima ovaj atribut ili metodu
    //npr: matematika za racunanje korijena - static da ju ne "pravimo" svaki put kada napravimo objekt
    //nestaticki atributi i metode smiju pristupati statickim clanovima
    /*
    class Math
    {
        public static double Sqrt (double value)
        {...}
    }
    double d = 35.0;
    Math.Sqrt(d);
    ovdje nam nije potrebno da pravimo cijeli objekt samo da bismo korjenovali d, pa nam je Sqrt static
    */

    //study tip - paziti na stvari koje nemamo u c# ali imamo u drugim oop jezicima jer oni mogu biti na usmenom
}

class Army
    {
        private static int BaseSoldierCost = 10; //koliko me kosta jedan vojnik
        private int soldiers; //broj vojnika

        public Army (int soldiers)
        {
            this.soldiers = soldiers;
        }

        public void IncreaseSoldierCost()
        {
            BaseSoldierCost++;
        }
        public int GetSoldierCost()
        {
            return BaseSoldierCost; //ovdje ne moramo navoditi Army.BaseSoldierCost jer smo u klasi
        }

        //primjer kad je static dobar
        public static Army Hire(int gold)
        {
            //staticki clanovi ne smiju pristupati nestatickim clanovima i zato nemaju this (atribut)
            //jedino smiju pristupati drugim statickim clanovima
            return new Army(gold / BaseSoldierCost);
        }

        public static Army Recruit(int population)
        {
            return new Army(population / 2);
        }
    }