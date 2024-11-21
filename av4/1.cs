//bit ce situacija kada imamo potrebu u C# izvesti klasu iz dvije bazne klase
//nije rjesenje npr ako zelimo bat izvesti iz mammal i bird, napraviti jos jednu klasu na levelu iznad, niti dodati metodu fly u mammal kad nam ne treba (dupliciranje)...
//rjesenje je sucelje - ugovor o ponasanju - sadrzi samo apstraktne metode i svojstva i tjera svakog tko ga naslijedi da implementira te metode i svojstva
//stavlja se veliko I kod imena sucelja - IFly
//smijemo naslijediti samo jednu klasu, ali puno sucelja, te i klasu i sucelje
//odnos koji nastaje suceljem je can-do, ali vrijedi i is-a
        
interface ILogger
{
    string Name { get; } //svi clanovi sucelja po defaultu su apstraktni i javni
    void LogInfo(string message);
    void LogError(string message);
}

class ConsoleLogger : ILogger
{
    //implementirati ili naslijediti sucelje
    public string Name {get {return "ConsoleLogger";}} //kad imamo one linere kao implementaciju (cijela metoda ili svojstvo je neki izraz), moze se zamijeniti s => (lambda opeartorom) - expression-bodied izraz - cisce je
    // public string Name => "ConsoleLogger";
    public void LogError(string message) =>LogMessage(message, ConsoleColor.Red);

    public void LogInfo(string message) => LogMessage(message, ConsoleColor.Green);
    private void LogMessage(string message ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{DateTime.Now}: {message}");
        Console.ResetColor();
    }
}
class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        Console.WriteLine(logger.Name);
        logger.LogInfo("Hello PI");
        logger.LogError("System32 deleted");
    }
}