//doma proci kroz ugradjene klase na Merlinu

namespace av2;
class Program
{
    static void Main(string[] args)
    {
        Complex c1 = new Complex(3, 9); 
        Console.WriteLine(c1.GetAsString());

        Complex c2 = new Complex(7); 
        Console.WriteLine(c2.GetAsString());

        Complex c3 = new Complex(2, 3);
        Complex c4 = c1 + c2 + c3;

        Complex c5 = c1 + 4;

        Random generator = new Random();
        int random_int = generator.Next();
        double random_double = generator.NextDouble();
        Complex random_complex = generator.NextComplex();
        Complex no_sugar = RandomExtensions.NextComplex(generator); //ista je kao i gornja linija
    }
}

//sintaksni secer
class RandomExtensions
{
    //mozemo napraviti NextComplex koji nam treba gore u main
    public static Complex NextComplex(this Random generator)
    {
        /*
        int re = generator.Next();
        int im = generator.Next();
        return new Complex(re, im);
        */
        return new Complex
        (
            generator.Next(), //Re
            generator.Next() //Im
        )
    }
}

//operatori su funkcije s lijepim imenom
//nemaju svi oop jezici mogucnost preopterecivanja funkcija
//zbrajanje je funkcija - kako cemo napraviti zbrajanje u smislu dva stola? za klasu stol zbrajanje po npr. duzoj stranici itd bi bila metoda s imenom JoinOnLongEdge
//nemoj mijenjati znacenje operatora npr. operator zbrajanje koji mnozi parametre
class Complex
{ 
    public int Real { get; private set; } //automatsko svojstvo

    public int Imaginary { get; private set; }
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

    //preoprterecivanje u c# radi se kao staticka funkcija
    public static Complex operaotr+ (Complex left, Complex right)
    {
        return new Complex( 
            left.Real + right.Real,
            left.Imaginary + right.Imaginary
        ); //boiler plate kod - kod koji je uvijek isti i uvijek ga moramo sami pisati
    }
    public static Complex operator +(Complex left, int value)
    {
        //mozemo staviti left.Real = 10; iako smo to dobili u parametru
        return new Complex( 
            left.Real + value,
            left.Imaginary
        );
    }

    public static bool operator >(Complex left, Complex right)
    {
        return (left.CalculateModulus() > right.CalculateModulus());
    }
    //compiler se na > buni jer ako imamo >, treba nam i < i =
    //na ispitu je dosta napisati jedan

    public static bool operator <=(Complex left, Complex right)
    {
        return !(left > right); //ako nije veci, onda je manji ili jednak - koristimo gornji >
    }

    public static bool operator <(Complex left, Complex right)
    {
        return !(right > left);
    }

    //public double CalculateModulus(complex c)
    //Complex dumb = new Complex(3, 8);
    //double modulus = dumb.CalculateModulus(dumb);
    //nikako ovo ne raditi
    public double CalculateModulus()
    {
        return Math.Sqrt(Real*Real + Imaginary*Imaginary) //staticke klase su klase koje imaju samo staticke clanove - npr Math
    }
}

/*
class StudentError
{
    private int value = 10;
    public int Value { get; set; }
}

StudentError error = new StudentError();
error.Value = 20;

value nema nikakve veze s Value
ako imamo atribut moramo napisati potpuno svojstvo
automatska svojstva ne mozemo kombinirati s atributom
*/

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