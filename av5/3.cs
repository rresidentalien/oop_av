internal class Program
{
    static void Main()
    {
        Stack stack = new Stack(3);

        try
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4); //stack overflow
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

class Stack
{
    private int sp;
    private int[] items;

    public Stack(int size)
    {
        this.items = new int[size];
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

        public int Pop()
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

class StackOverflowException : Exception
{
    private int ImportantValue //dovrsiti
    public StackOverflowException() : base() {}
    
    public StackOverflowException(string message) : base(message) {}
}

//genericki tipovi:
//napravili smo stack za intove
//sto ako zelimo stack za stringove? kompleksne brojeve?
//logika stacka je uvijek ista bez obzira sto mi stavimo u njega
//rjesenje: opceniti tip / placeholder za tip
//u trenutku instanciranja biramo tip