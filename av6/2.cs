 //klasa koja omogucuje da u nju pohranjujemo kljuc i vrijednost, jedna od najkoristenijih struktura u programiranju
//kada uvodimo vise generickih tipova, prefiksamo ih s T i dajemo ime koje ukazuje na znacenje
//pretraga u dictionaryju se radi preko kljuca - brzo
Dictionary<string, double> studentGrades = new Dictionary<string, double>();
studentGrades.Add("Marko", 3.2);
studentGrades.Add("Ivana", 4.7);

foreach (var studentGrade in studentGrades) //var je zapravo KeyValuePair<string, double>
{
    Console.WriteLine(studentGrade.Key);
    Console.WriteLine(studentGrade.Value);
}

studentGrades["Marko"] = 4.8;
Console.WriteLine(studentGrades["Marko"]);

//mogli smo npr umjesto double staviti listu ocjena
//pravilo je ne raditi sa sirovim strukturama nego ih staviti unutar klase i interno koristiti npr. rijecnik - sto korisnik ne mora znati

//ne pisati gettere na internu listu!! cijeli api liste je tada javan
//radije dati nacine za pristup pojedinim elementima liste
//sakriti podatkovne strukture unutar klase i dati npr. ovdje metodu za unos ocjene

studentGrades.Add("Marko", 3.7); //argument exception jer vec imamo Marka (dodaj vs dodaj i promijeni)

//kljuc se ne moze promijeniti

//Add na dictionaryju i hash setu moramo znati, neke jako specificne stvari ce se napomenuti na ispitu