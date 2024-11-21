interface ILogger
{
    string Name {get;} //svi clanovi sucelja po defaultu su apstraktni i javni
    void LogInfo(string message);
    void LogError(string message);
}

class ConsoleLogger : ILogger
{
    public string Name => "ConsoleLogger";
    public void LogError(string message) => LogMessage(message, ConsoleColor.Red);

    public void LogInfo(string message) => LogMessage(message, ConsoleColor.Green)
    {
        
    }
    private void LogMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{DateTime.Now}: {message}");
        Console.ResetColor();
    }
}

class FileLogger : ILogger
{
    private string filename;
    public FileLogger(string filename)
    {
        this.filename = filename;
    }
    public string Name => "FileLogger";
    public void LogError(string message) => LogMessage(message, "ERROR");

    public void LogInfo(string message) => LogMessage(message, "INFO");

    private void LogMessage(string message, string tag)
    {
        //using block:
        using (var writer = new StreamWriter(this.filename, true))
        {
            writer.WriteLine($"{tag} {DateTime.Now} {message}");
        }
        //ako nesto podje po krivu, using ce sam otpustiti resurse i ne moramo se mi brinuti o tome
        //C# podrzava type inference - ne moramo eksplicitno navesti tip varijable, nego mozemo staviti placeholder var
        //var se vrlo cesto koristi u foreach petljama da ne moramo pisati puno ime jer se zna po onome sto mu se pridjeljuje koji je njegov tip

        //StreamWriter writer = new StreamWriter(this.filename, true); //true = append, false = truncate
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

        //polje puno referenci, ne objekata - zato je legalno
        //C++ bi stvorio objekte
        ILogger[] loggers = new ILogger[]
        {
            new ConsoleLogger();
            new FileLogger("mylog.txt");
        };

        foreach(var log in loggers)
        {
            log.LogInfo("Hello!");
            log.LogError("System32 deleted");
        }
    }
}

//ako nasljedjujemo vise sucelja, moramo javno imati sve metode iz svih sucelja
//sucelje sadrzi sve apstraktne clanove, apstraktna klasa ne mora
//mozemo naslijediti vise sucelja, ali ne i klasa
//kad trebamo samo ponasanja, sucelje je bolji izbor, u suprotnom apstraktna klasa (npr ako trebamo virtualne metode s defaultnom implementacijom)