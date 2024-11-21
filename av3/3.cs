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

    public override string ToString()
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

    public override string ToString()
    {
        return base.ToString() + $"{tribe}"; //protected i public metode smiju se koristiti u izvedenim klasama
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
        int a = 10;
        double d = a;
        Console.WriteLine(d); //idemo u precizniji tip, int moze biti spremljen u double bez gubitka informacija i zato mozemo ovo raditi

        double pi = 3.14;
        int notPi = (int)pi; //ovo se ne smije, nego se eksplicitno mora reci

        Elf elf = new Character("", 10);
        Character c = elf; //svaki objekt izvedenog tipa mogu gledati preko reference osnovnog tipa i zato smijemo ovo raditi - upcast
        Elf pointerToElf = (Elf)c; //compiler ne moze znati sto je c i moramo biti eksplicitni - downcast

        //castanje klasa je relativno cesta stvar

        Elf newElf = (Elf)Generate(); //moze doci bilo koji od orc, elf, character i zato moramo eksplicitno castati u elf

        object o = elf //object je korijenska klasa
        //sadrzi virtualne metode koje mozemo overridati i u pravilu to i zelimo (lv2 - ToString override)

        //overrideani gethashcode() i equals() - npr umjesto razlicitih adresa kao mjera za razlikovanje objekata, gledat ce se jmbag i ime studenta - ako su oni isti, objekti su isti

        /*
        Derived d1 = new Derived();
        Base b1 = d1;

        problem nastaje kad idemo u kontra smjeru:
        Base b2_really_d1 = (Derived)b1;
        kompajler ne moze znati koji je objekt iza b1 pa mu moramo eksplicitno reci
        base u derived - downcasting i mora biti eksplicitan
        derived u base - upcasting
        */
    }

    public static Character Generate()
    {
        Random generator = new Random();
        switch(generator.Next(0, 3))
        {
            case 0 : return new Orc(" ", 10, "", false);
            case 1 : return new Character(" ", 10);
            case 2 : return new Elf(" ", 10);

        }

        return new Character(" ", 10);
    }
}