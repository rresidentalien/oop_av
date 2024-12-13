

namespace av6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            HashSet<int> numbers = new HashSet<int>(); //HashSet ne garantira poredak elemenata, za to mozemo koristiti SortSet
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(2);//ne smije imati duplikate
            Console.WriteLine(string.Join(",", numbers));

            //HashSet moze sadrzavati dva razlicita objekta istog tipa i sadrzaja jer imaju drugaciji hash code

            record Student { string name; } //slicno data klasi u Kotlinu, automatski izgenerira tostring, gethashcode, ne postoji u svim oop jezicima

            HashSet<int> primes = new HashSet<int>() {7, 11};
            numbers.UnionWith(primes);
            numbers.IntersectionWith(primes);

            string name = "Objektno orijentirano programiranje";
            var letters = name.ToHashSet();
            Console.WriteLine(string.Join(",", letters)); //dobili smo sve znakove koji se pojavljuju u stringu, najcesci nacin koristenja hash seta, ovo koristiti u ispitu, ako cemo korisiti za sebe moramo overrideati equals i getHashCode
        }
    }

    
}