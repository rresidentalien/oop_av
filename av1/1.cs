namespace av1
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");
            Dog charlie = new Dog();
            charlie.name = "Charlie";
            Console.WriteLine(charlie.name); //ilegalno, ali to cemo rjesiti kada dodjemo do enkapsulacije
            Console.WriteLine(charlie.Bark());

            Dog atos = new Dog();
            atos.name = "Atos";
            Console.WriteLine(atos.name); //ilegalno, ali to cemo rjesiti kada dodjemo do enkapsulacije
            Console.WriteLine(atos.Bark());

            //stavljamo int i jer nam kasnije ne treba, zelimo da zivi sto je najkrace moguce
            for(int i = 0; i < 10; ++i) //ne koristiti magicne brojeve nego staviti konstantu
            {
                Dog d = new Dog();
                d.name = $"Dog_{i+1}"; //svaki pas ce imati ime Dog i neki broj
                Console.WriteLine(d.name);
            }
        }
    }

    public class Dog
    {
       public string name; //ne stavljati public inace! ovo je samo za vjezbu
       public string breed;
       public int age;

       public string Bark()
       {
        return "Woof woof";
       }
    }
}