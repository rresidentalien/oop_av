//ovisnost u oop - kad jedna klasa ne moze bez neke druge klase
//znamo odnose: is-a, has-a, uses (asocijacija), can-do
//objekti ovise o drugim objektima
//bolje nam je ovisiti o apstraktnim nego konkretnim stvarima
//tako mozemo imati vise nacina za obaviti istu stvar
//npr mozemo voditi biljeske na tabletu, laptopu, biljeznici...
//znamo voditi biljeske bez obzira na nacin biljezenja
//ako znamo voditi biljeske samo u biljeznicu, treba nam druga instanca osobe da bi ih mogla biljeziti na laptop

class Product
{
    public decimal Price {get; private set;}
    public int Quantity {get; private set;}

    public Product(decimal price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }
    public void AddItem() => Quantity++;
    public void RemoveItem()
    {
        if (Quantity > 0)
            Quantity--;
    }
}

class Cart
{
    List<Product> prodcuts;
    IDiscount discount; //labava veza izmedju Cart i Discount
    //ne zelimo imati sve moguce vrste popusta u klasi Cart nego cemo ga odvojeno modelirati

    public Cart()
    {
        this.prodcuts = new List<Product>();
        this.discount = new PercentageDiscount(0.2m);

        public Cart(IDiscount discount)
        {
            this.prodcuts = new List<Product>();
            this discount = discount;
        }

        public void ChangeDiscount(IDiscount discount)
        {
            this.discount = discount;
        }

        public void Add(Product product) => prodcuts.Add(product);
        public void Remove(Product product) => prodcuts.Remove(product);

        public decimal CalculateTotal()
        {
            decimal total = 0.0m;
            foreach(var product in products)
            {
                total += product.Price * product.Qauntity;
            }
            return discount.CalculateDiscountedPrice(total); //popust na cijelu kosaricu
        }
    }
}

interface IDiscount
{
    decimal CalculateDiscountedPrice(decimal price);
}

class FlatDiscount : IDiscount
{
    private decimal amount;

    public FlatDiscount(decimal amount)
    {
        this.amount = amount;
    }

    public decimal CalculateDiscountedPrice(decimal price)
    {
        return Math.Max(0, price - amount);
    }
}



class PercentageDiscount : IDiscount
{
    decimal percent;

    public Discount(decimal percent)
    {
        this.percent = Math.Clamp(percent, 0.0m, 1.0m); //m je za decimal tip
    }

    public decimal CalculateDiscountedPrice(decimal price) //radimo s novcima pa zelimo biti precizni i koristimo decimal ili klasu Money, nikada int ili double
    {
        return price - price * percent;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cart cart = new Cart(new PercentageDiscount(0.3m));
        cart.Add(new Product(100, 10));
        Console.WriteLine(cart.CalculateTotal());
        cart.ChangeDiscount(new PercentageDiscount(0.7m));
        Console.WriteLine(cart.CalculateTotal());
    }
}

//ubrizgavanje ovisnosti / dependency injection - mehanizam kako cemo staviti jedan objekt u drugi
//na vecem projektu IOC container ce nam ubrizgavati stvari koje nam trebaju
//mi to radimo ili kroz setter ili kroz konstruktor

//pitanje za kraj: imamo i konstruktor i setter
//sto je bolja praksa?
//bolje je koristiti konstruktor jer nam je ovisnost odmah vidljiva
//ne zelimo napraviti da se objekt moze stvoriti, bude null, i tek kasnije se postavlja setterom i program ce se srusiti
//obavezno inicijalizirati sva stanja koje imamo u klasi

//jedna od najcescih stvari u oop i bez ovoga ne mozemo