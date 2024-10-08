namespace av1
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");
            Dog charlie = new Dog();
            charlie.SetName("Charlie");
            Console.WriteLine(charlie.GetName());
            Console.WriteLine(charlie.Bark());

            Dog atos = new Dog();
            atos.SetName("Atos");
            Console.WriteLine(atos.GetName());
            Console.WriteLine(atos.Bark());

            //stavljamo int i jer nam kasnije ne treba, zelimo da zivi sto je najkrace moguce
            for(int i = 0; i < 10; ++i) //ne koristiti magicne brojeve nego staviti konstantu
            {
                Dog d = new Dog();
                d.SetName($"Dog_{i+1}"); //svaki pas ce imati ime Dog i neki broj
                Console.WriteLine(d.GetName());
            }

            Console.WriteLine(charlie.CreateReport());
            charlie.age = 7;
            Console.WriteLine(charlie.Age);
        }
    }

    public class Dog
    {
       private string name; //popravljeni public atributi
       private string breed;
       private int age;

       //svaka klasa ima konstruktor bez da ga mi napisemo
       public Dog() {} //defaultni konstruktor, compiler ga napravi bez da ga mi napisemo

       //pristupne metode - accessori i getteri/setteri: pristup privatnim atributima
       public string GetName()
       {
        return name;
       }

       public void SetName(string name) //ne treba nista vratiti
       {
            name = this.name; //ne davati glupa imena varijabli (npr nname) nego koristiti this - referenca na samog sebe - "u atribut pohrani vrijednost koju si dobio kao argument"
            //uvijek pisati kod tako da nema iznenadjenja!!!! netko drugi mora moci nastaviti raditi na nasem kodu

            //this.name = name.ToUpper(); - postavii smo pravilo za upisivanje imena
       }

       //svojstva su zapravo getteri i setteri, ali ih je lakse koristiti jer imamo sve na jednom mjestu
       public int Age
       {
        get { return age; }
        set { age = Math.Max(0, value); } //value je kljucna rijec samo unutar set propertyja 
       }

        //automatsko svojstvo
       public string Gender { get; private set; } //izgenerirat ce za klasu atribut koji nama nece biti vidljiv, ali ni ne mora
       //koristimo kada ne zelimo gubiti vrijeme, a ne treba nam kontrola
       //dohvatiti ga mogu svi, a postaviti samo unutar klase

       string gender; //ovo je sasvim druga stvar

       public string Bark()
       {
        return $"Woof woof. My name is {name}";
       }

       public string CreateReport()
       {
        return $"DOG\n=======\n{Bark()}"
       }
    }
}