//genericki tipovi:
//napravili smo stack za intove
//sto ako zelimo stack za stringove? kompleksne brojeve?
//logika stacka je uvijek ista bez obzira sto mi stavimo u njega
//rjesenje: opceniti tip / placeholder za tip
//u trenutku instanciranja biramo tip

//metode mogu biti genericke
//imamo niz vrijednosti i zelimo ga zarotirati (prvi na zadnje mjesto itd)
//ova implementacija ne ovisi o tipu

//ako imamo vise tipova, pisemo ih kao T(nekoIme), T(drugoIme) itd

internal class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>(3);
        Stack<string> names = new Stack<string>(3);

        int[] items = new int[] { 1, 2, 3, 4 };
        ArrayUtilities.Reverse(items);
        Console.WriteLine(string.Join",", items);
        
        ArrayUtilities.FindMin(items);

        try
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4); //stack overflow
            
            names.Push("Katarina");
            names.Push("Ime");
            names.Push("Ime");
        }
        catch (StackOverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (StackOverflowException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

class Stack<T>
{
    private int sp;
    private T[] items;
    

    public Stack(T size)
    {
        this.items = new T[size];
        this.sp = -1;

        public void Push(int item)
        {
            if (this.IsFull())
            {
                thow new StackOverflowException("Cannot push to full stack, illegal action!");
            }
            sp++;
            this.items[sp] = item;
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new StackUnderflowException();
            }
            return this.items[sp--];
        }

        private bool IsFull() => sp == items.Length - 1; //expression bodied method
        private bool IsEmpty() => sp == -1; //simetrija!

    }
}

class StackOverflowException : Exception
{
    private int ImportantValue //dovrsiti
    public StackOverflowException() : base() {}
    
    public StackOverflowException(string message) : base(message) {}
}

class StackUnderflowException : Exception
{
    private int ImportantValue //dovrsiti
    public StackUnderflowException() : base() {}
    
    public StackUnderflowException(string message) : base(message) {}
}

class ArrayUtilities
{
    public static void Reverse<T>(T[] items)
    {
        for (int i = 0; i < items.Length / 2; i++)
        {
            int swapIndex = items.Length - 1 - i;
            T temp = items[i];
            items[i] = items[swapIndex];
            items[swapIndex] = temp;
        }
    }

    public static T FindMin<T>(T[] items) where T : IComparable<T> //jedna jedina metoda - CompareTo, genericko sucelje
    {
        T min = 0;

        for (int i = 0; i < items.Length; ++i)
        {
            /*if (items[i] < items[min]) //ne mozemo koristiti operator jer ne mozemo osigurati da tip T ima implementiran operator < (a ne mozemo ga ni natjerati)
            //ali mozemo reci da ova metoda radi samo za one tipove T koji su usporedivi
            {
                min = i;
            }*/

            if (items[i].CompareTo(items[min]) < 0)
            {
                min = items[i];
            }
        }
        
        return items[min];
    }
}

