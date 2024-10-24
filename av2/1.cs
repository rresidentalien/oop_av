namespace av2;
class Program
{
    static void Main(string[] args)
    {
        Complex c1 = new Complex(); //defaultni konstruktor - postoji bez da ga mi radimo, compiler ga napravi za nas
        Console.WriteLine(c1.GetAsString()); //dobivamo 0+0i - u memoriji se za defaultni konstruktor stavljaju nule koje se interpretiraju kao 0 za int, false za boolean itd.
    }
}

//ne smijemo dio pisati u inicijalizatoru, a dio u konstruktoru - ako pisemo konstruktor onda stavimo sve u njega
class Complex
{ 
    public int Real { get; private set; } //automatsko svojstvo
    //compiler kreira pristupne metode u koje mi nemamo uvid
    //mozemo pozvati get izvan klase, ali ne i set - set samo unutar klase jer je private

    public int Imaginary { get; private set; }

    //cim napravimo bilo kakav konstruktor, nestaje defaultni
    //svaka klasa mora imati konstruktor, ako mi nismo napravili onda compiler pravi defaultni
    public Complex(int real, int imaginary)
    {
        this.Real = real;
        this.Imaginary = imaginary;
    }
    public string GetAsString()
    {
        string sign = Imaginary < 0 ? "" : "+"; //ako je im < 0 stavi prazan string, u suprotnom stavi +
        return $"{Real}{sign}{Imaginary}i" //radimo novi string na temelju manjih
        //na Real i Imaginary se radi automatska konverzija u string iz int
    }
}