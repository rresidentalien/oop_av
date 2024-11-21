abstract class Character
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

    public abstract void Heal()
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

    public override void Heal()
    {
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

    public override void Heal()
    {
        Hp += 100;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //ako klasu proglasimo apstraktnom, ne mogu se stvarati objekti te klase
        //iduci put radimo sucelja

        //ako imamo klasu shape i izvedemo square, pyramid, etc, sto shape treba sadrzavati i kako bi on izgledao da ga pokusamo nacrtati?
        //shape nije konkretan i on bi trebao biti apstraktna klasa
        //isto tako i character

        //ako character stavimo kao apstraktan, ne mozemo imati instance te klase

        //ako zelim prisiliti svaku od izvedenih klasa da ima neko ponasanje, to se deklarira kao public abstract
        //ako naslijedim apstraktnu klasu koja ima apstraktne metode, i izvedena klasa ima tu apstraktnu metodu

        //cijela poanta apstraktne klase - u njoj implementiramo defaultno ponasanje
        //takodjer i da prisilimo sve izvedene klase da implementiraju apstraktne metode
        //mehanizam da sigurno znamo da cemo imati neko ponasanje u svim izvedenim klasama - ocekujemo to ponasanje

        //ako ne overrideamo virtualnu metodu, koristit ce se ona iz base klase
        //apstraktna se mora overrideati
        //apstraktne metode su podrazumijevano virtualne
    }
}