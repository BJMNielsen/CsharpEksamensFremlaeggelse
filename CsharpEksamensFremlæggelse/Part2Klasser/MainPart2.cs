namespace CsharpEksamensFremlæggelse.Part2Klasser;

public class MainPart2
{
    public static void Run()
    {
        // En klasse i C# er en skabelon for at skabe objekter og definerer formen af et bestemt data-type.
        // Den beskriver, hvilke data et objekt kan indeholde, og hvilke operationer det kan udføre.


        //   MEMBERS   \\ --------------------------------------------------------------------------

        // En klasse kan have forskellige typer af medlemmer:
        // fields_ (private)
        // properties (public)
        // metoder,
        // konstruktører,
        // events, indexers, operatører, nestede typer og finalizers.


        //   ACCESSIBILITY, OBJECT INITIALIZERS, CONSTRUCTORS, OBJECT INITIALIZERS   \\ --------------------------------------------------------------------------
        // I C# bruges accessibility-niveauer (også kendt som adgangsmodifikatorer) til at styre adgangen til klasser og deres medlemmer
        // (som felter, metoder, konstruktører osv.). Disse modifikatorer bestemmer, hvilken kode der kan få adgang til disse klasser og medlemmer.

        Person p1 = new Person(2) { Name = "Lars" };
        // p1._name kan vi ikke få fat i da _name er private.
        p1.Age = 2; // Age og Name kan vi få fat i, da de er public.
        p1.Name = "Børge";
        // Protected kan også bruges, det extender private access til alle nedarvninger også fx
        
        
        //   ARV   \\ --------------------------------------------------------------------------
        
        Bil minBil = new Bil();
        minBil.Mærke = "Toyota"; // Arvet fra baseklassen Køretøj
        minBil.AntalDøre = 4; // Property der tilhøre derived class "Bil"
        minBil.Start(); // Arvet metode fra Køretøj
    }

    public class Person
    {
        // This is a field. It's common to make fields private.
        private string _name;

        // This is a property. By using this, you can control the access to the field.
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age { get; set; }

        public Person(int age)
        {
            Age = age;
        }
    }


// Baseklasse
    public class Køretøj
    {
        public string Mærke { get; set; }

        public void Start()
        {
            Console.WriteLine("Køretøjet starter.");
        }
    }

// Derived klasse
    public class Bil : Køretøj
    {
        public int AntalDøre { get; set; }
    }
}