namespace av1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dog rex = null;
            string gender = rex.Gender; //ovo je kao da imamo null pokazivac

            Dog charlie = new Dog();
            Console.WriteLine(charlie.GetName().ToLower);

            Farm farm = new Farm("FERIT", 4);
            Console.WriteLine(farm.GetMorningDescription());
        }
    }

    //automobil - vise sustava koji su zasebne klase i sadrze objekte drugih klasa

    class Farm
    {
        private string address;
        private Dog dog;

        public Farm(string address, int count)
        {
            this.address = address;
            this.dog = new Dog[count];
            for(int i = 0; i < this.dog.length; i++)
            {
                this.dog[i] = new Dog();
            }
        }

        public string GetMorningDescription()
        {
            //return $"{address}\n{dog.Bark()}";
            //dobit cemo gresku null reference exception ako nemamo deskriptor

            string.description = "";
            for(int i = 0; i < this.dog.length; i++)
            {
                GetMorningDescription += this.dog[i].GetName();
            }
        }
    }

    public class Dog
    {
       private string name; //popravljeni public atributi
       private string breed;
       private int age;

       //defaultni konstruktor
       public Dog() 
       {
            this.name = "Dog";
            this.breed = "German Shepherd";
            this.age = 0;
            this.Gender = "Male";
       }

        //preopterecivanje funkcija
       public Dog(string name, string breed, string gender) : this(name, breed, 0, gender)
       {
            /*this.name = name;
            this.breed = breed;
            this.age = 0;
            this.Gender = gender;*/
       }

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