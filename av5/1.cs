//imenici, iznimke, parametarski polimorfizam

//using kaze "nadji ovaj prostor imena, uzmi sve iz njega i ubaci ga ovdje"
//lista se npr nalazi u System.Collections.Generic
using System.Collections.Generic;

namespace Namespaces //doslovno prostor imena, sve sto stavimo tu nije vidljivo negdje drugdje
//na vecim projektima nije odrzivo da nam sav kod bude na istom mjestu -> razdvajamo prostore imena
using Students; //moramo u ovaj namespace dodati drugi da bismo mogli koristiti njegove klase
{
    class Student
    {
        private List<int> numbers;
    }

    internal class Program()
    {
        static void Main()
        {
            Student student = new Student(); //Student je u drugom namespaceu pa ga ne mozemo samo ovako koristiti
            Teacher teacher = new Teacher();
            Students.Student anotherStudent = new Student(); //fully qualified name
            //mozemo imati istoimene klase iz razlicitih imenika
        }

    }
}

namespace Students
{
    public class Student
    {
        private Teacher teacher = new Teacher(); //ovo ne radi, moramo koristiti using
    }
    //svaka klasa i dalje ide u odvojene datoteke, samo gore dodajemo namespace Students
    //u visual studio - ako napravimo klasu u folderu, ime tog foldera ce biti podimenik imenika solutiona
    //ti folderi su za grupiranje koda
    public class Subject
    {
        
    }
}

//podimenici

namespace Student.Staff //staff je podimenik od student
{
    public class Teacher
    {
        private Student student = new Student(); //ovo radi jer je staff podimenik studenta
    }
}

//na vecem projektu radimo vrsni imenik - npr ime tvrtke i odandje radimo podimenike
//moze se granati koliko zelimo, ali obicno to bude do 5-6

/*
 *ako napisemo:
 * namespace App.Demo;
 * internal class Demo
 ta klasa pripada namespaceu ali je urednije jer nam nije cijela klasa uvucena za jedan tab
 */
 
