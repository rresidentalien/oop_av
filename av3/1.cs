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

    public Character()
    {
        Console.WriteLine("Def. ctor Character");
        this.name = "Unknown Hero";
        this.hp = 100;
    }

    public Character(string name, int hp)
    {
        Console.WriteLine("Param. ctor Character");
        this.name = name;
        this.hp = hp;
    }

    public string GetAsString()
    {
        return $"{name} {hp}"
    }
}

class Orc : Character //sintaksa nasljedjivanja, nemamo modifikator pristupa nego samo obicno nasljedjivanje
{
    private string tribe;
    private bool isEnraged;

    public Orc(string tribe, bool isEnraged)
    {
        this.tribe = tribe;
        this.isEnraged = isEnraged;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Character ashenOne = new Character();
        Console.WriteLine(ashenOne.GetAsString());

        Orc orc1 = new Orc("Forest", false);
        Console.WriteLine(orc1.GetAsString()); //Unknown Hero, 100 - privatne stvari su se naslijedlie
    }
}