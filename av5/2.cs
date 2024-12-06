//sto radimo ako korisnik napravi nesto sto mi nismo definirali?
internal class Program
{
    static void Main()
    {
        try
        {
            HealthCalculator calculator = new HealthCalculator();
            Console.WriteLine("In try");
            Console.Write("Enter height: ");
            double height = double.Parse(Console.ReadLine()); //ovdje parse puca s iznimkom -> catch blokovi
            //prvi koji odgovara iznimci koja je bacena izvodi se
            //nakon toga se ide na finally
            Console.writeline(height);
            Console.WriteLine("Enter weight: ");
            double weight = double.Parse(Console.ReadLine());

            double bmi = calculator.Calculate(height, weight);
            Console.WriteLine(bmi);
        }
        catch (ArgumentException e) //cesta imena: e, ex
        {
            Console.WriteLine("Argument Exception");
            Console.WriteLine(e.Message);
            throw; //ispisi svoje i baci dalje - svaki modul moze reagirati na svoj nacin, popraviti svoje probleme i proslijediti dalje
            //to radimo ovako umjesto da bacamo ponovno jer se nece izgubiti stack trace - mozemo pratiti sto je poslo po krivu
        }
        //ako imamo vise catch blokova, pisemo ih od najpreciznijem do najopcenitijeg, a najopcenitiji MORA biti zadnji
        //prvi koji se uhvati ce se izvesti pa nam onda provjere gresaka nece raditi kako smo zamislili
        catch (Exception e) //hvata bilo koji error jer je osnovni tip za sve exceptione
        {
            Console.WriteLine(e.Message);
            Console.ReadLine("In catch");
            //return; - mozemo i ovo
        }
        finally
        {
            Console.WriteLine("In finally");
        }
        Console.WriteLine("Still running!");
        
        //upisemo broj i sve normalno radi
        //sto ako rijecima upisemo npr "sto devedeset devet"?
        
        //kada compiler nije uspio procitati to kao broj, javlja gresku tako sto podigne/baci iznimku (exception)
        //mozemo ga uhvatiti ako zelimo na njega reagirati
        //moramo imati mehanizam kojim cemo se oporaviti od greske -> iznimka
        //s ovim blokovima program nece puknuti nego ce samo uci u catch blok i nastaviti se izvoditi
        //finally nije obavezan, try i catch jesu (neki jezici ni nemaju finally)
        
        //using blok je try/catch/finally koji na kraju otpusta sve resurse
    }
}

class HealthCalculator
{
    public double CalculateBMI(double heightMeters, double weightKg)
    {
        if (heightMeters <= 0)
        {
            //throw new Exception(""); - preopcenito - "hej bio je problem"
            //zelimo maksimalno pozivatelju pomoci u pronalazenju greske - koristiti najprikladniju mogucu iznimku
            throw new ArgumentException($"Parameter {nameof(heightMeters)} was {heightMeters} but cannot be less or equal to zero}");
            //throw u ovom trenutku znaci moras stati s izvodjenjem
            //nije u try bloku jer u ovoj metodi nemamo znanja ni mogucnosti popraviti problem
            //onaj tko je zvao funkciju ce se snalaziti s problemom i ako se ne uhvati, srusit ce program
            //ako ju mi uhvatimo i obradimo, ne mora se program srusiti
        }
        return weightKg / (heightMeters * heightMeters);
    }
}

//double za dijeljenje s 0 ne daje exception nego beskonacno
//ne raditi duboka grananja exceptiona!
//ako pisemo vlastitu iznimku, na ispitu nam treba samo prva dva overloada (bez parametara i s parametrom string)
//kroz tip iznimke sugeriramo sto je problem - sami throw bas i ne zna nista, to je samo poruka