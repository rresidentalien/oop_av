//osim kompozicije (has a), druga i jača vrsta odnosa u oop je "IS A" 
//ova dva odnosa su nam vrlo bitna, ali nemojte zapadati u zamku da ono sto je "has a" stavite kao "is a"
//ljudi disu, studenti isto disu - kako mozemo biti dvije stvari u isto vrijeme?
// a student IS A human

//Farm: cow, horse, pig (has a)
//cow: milkPerDay, age / move(), giveMilk()
//horse: power, age / move(), runRace()
//pig: weight, age / move(), makeCrunchies()

//sada na tri mjesta imamo implementiranu metodu move i varijablu age
//to su tri mjesta na kojima moramo raditi projmenu, jos gore postaje ako ih imamo jos vise
//bilo bi super kada bi ove zajednicke metode i atribute mogli staviti u jednu klasu
//to je moguce s nasljedjivanjem: cow IS A animal i klasa animal ima age / move()
//extended, derived etc. class - izvedena klasa


class Character
{
    private string name;
    private int hp;

    public Character(string name, int hp)
    {
        Console.WriteLine("Param. ctor Character");
        this.name = name;
        this.hp = hp;
    }

    public virtual string GetAsString()
    {
        return $"{name} {hp}"
    }

    public virtual int Attack()
    {
        return hp;
    }

    //pristupa privatnom clanu unutar klase, to je dopusteno
    protected string GetNickname()
    {
        return name.ToUpper();
    }
}

class Orc : Character //sintaksa nasljedjivanja, nemamo modifikator pristupa nego samo obicno nasljedjivanje
{
    private string tribe;
    private bool isEnraged;

    public Orc(string name, int hp, string tribe, bool isEnraged) : base(name, hp) //zove param. ctor klase iz koje je izveden i njemu postavlja name i hp
    {
        Console.WriteLine("Param. ctor")
        this.tribe = tribe;
        this.isEnraged = isEnraged;
    }

    public override string GetAsString()
    {
        return name; //privatnom clanu name ne moze se pristupiti iz izvedene klase iako ga sadrze
        return this.GetNickname() + this.GetAsString(); //protected i public metode smiju se koristiti u izvedenim klasama
        //dio funkcionalnosti izvedenih tipova izvodi se pomocu osnovnih tipova
        //zelimo koristiti funkcionalnosti koje vec imamo
    }

    public override int Attack() //promijenjeno ponasanje u izvedenoj klasi u odnosu na osnovnu
    {
        if (isEnraged)
        {
            return base.Attack() * 2;
        }
        else
        {
            return base.Attack();
        }
    }

    public int Hp
    {
        get {return hp;}
        set {this.hp = Math.Max(0, value);}
    }

    public void Heal()
    {
        //ne mozemo pristupiti hp-u - mali problem
        //mozemo hp staviti kao protected, ali to ne zelimo
        //kada pisemo klase moramo ih napraviti da budu namijenjene za nasljedjivanje
        //i to isto pisemo preko get set propertyja ako zelimo, ali moramo kontrolirati atribute
        //ne zelimo da izvedene klase ne postuju ogranicanje koje smo postavili u setteru

        this.Hp = 100;
    }
}

class Elf : Character
{
    //konstruktori se ne nasljedjuju
    public Elf (string name, int hp) : base(name, hp) //ovo nije deklaracija! samo se dobiveni argument prosljedjuje drugom konstruktoru tj onom iz osnovne klase
    {

    }
    public override int Attack()
    {
        return base.Attack() / 2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Character ashenOne = new Character("Hero", 100);
        Console.WriteLine(ashenOne.GetAsString());

        Orc orc1 = new Orc("Orc", 100, "Forest", false);
        Console.WriteLine(orc1.GetAsString()); //skrivanje metode

        Character orc2 = new Orc("Urk", 100, "Water", true); //referenca je uosnovnog tipa, referenca na kojeg pokazuje je tipa orc; jedino sto s njim mozemo je ono sto moze osnovna klasa, ne i izvedena klasa
        Console.WriteLine(orc2.GetAsString());
        orc2.Heal() //ne mozemo healati orc2 jer je on definiran u izvedenoj klasi
        //osnovna klasa ne zna nista o izvedenoj klasi
        Console.WriteLine(orc2.Attack()); //koristit ce onaj Attack iz klase Character, u izvedenoj vraca 2x hp ako je enraged
        //imamo objekt orc ali ga promatramo iz perspektive tipa character - to je polimorfizam
        //static binding - iako imamo specijalizirano ponasanje, compiler prvo pri prevodjenju vidi tip Character

        //overriding metode - izvedene metode, kako bi dobili novo ponasanje umjesto onoga iz osnovne metode
        //ovo je zeljeno ponasanje
        //virtualne metode - osnovne metode

        Elf legolas = new Elf("Legolas", 100);

        Character[] characters = new Character[]
        {
            ashenOne, legolas, orc2
        };

        foreach (Character character in characters)
        {
            Console.WriteLine(character.Attack()); //mozemo korisiti sve sto je u osnovnoj klasi, ali svejedno dobivamo ponasanje metode izvedene klase - JAKO VAZNO!
        }

        //za svaku klasu definira se tablica virtualnih funkcija i svaka klasa ima virtual pointer
        //ako ima virtualnu metodu, to mora postojati
        //jedna tablica po klasi, nema svaki objekt svoju
        //implementacija je u osnovnom tipu klase
        //ako iz osnovne klase izvedemo d1 i u njoj imamo njezin pointer i njezinu tablicu
        //function1 ne pokazuje vise gore, nego na klasu koja je najzivedenija
        //uvijek se poziva najizvedenija metoda kod overrideanja
        //da iz orca izvedem svetog orca npr., i on ne overridea Attack(), na njemu bi se pozvao Attack() orca jer je on najizvedeniji koji postoji
        //vertikalno nasljedjivanje ide koliko god zelimo (ali nije pametno ici jako duboko)
        //u c# smijemo naslijediti samo jednu klasu (single inheritance jezik), dok je cpp multiple inheritance jezik
        //kad naslijedimo dvije klase to moze biti problem i tesko je baratati time, zato su mnogi jezici single inheritance
        //cpp zato ima virtualno nasljedjivanje - procitati jer moze biti na usmenom
    }
}

//na objekte mozemo gledati kao tip bilo koje klase, osnovne ili izvedene