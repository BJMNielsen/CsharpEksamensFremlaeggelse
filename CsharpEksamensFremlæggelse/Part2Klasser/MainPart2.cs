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
        
        Car minCar = new Car(); // Bruger no arg constructor der udnytter constructor chaining to chain a call til en base (Vehicle) class constructor
        minCar.DisplayInfo();
        minCar.Year = 2010; // Variablen Year er Arvet fra baseklassen Vehicle
        minCar.Model = "Toyota"; // Variablen Model er Arvet fra baseklassen Vehicle
        minCar.HorsePower = 4; // Variablen der tilhøre derived class Car
        minCar.DisplayInfo(); // Metode der er derived class Car, som tager brug af den samme metode i base klassen Vehicle
        Console.WriteLine();
        
        
        //   STATIC VS DYNAMIC METHOD DISPATCH   \\ --------------------------------------------------------------------------
        
        // STATIC 
        BaseClass bc = new BaseClass();
        Console.Write("BaseClass bc = new BaseClass(): ");
        bc.StaticMethod();
        BaseClass bcdc = new DerivedClass();
        Console.Write("BaseClass bcdc = new DerivedClass(): ");
        bcdc.StaticMethod();
        DerivedClass dc = new DerivedClass();
        Console.Write("DerivedClass dc = new DerivedClass(): ");
        dc.StaticMethod();
        Console.WriteLine("Dvs den eneste måde vi når ned til StaticMethod i DerivedClass klassen er, hvis vi instantiere et new DerivedClass objekt fra datatypen DerivedClass ");
        Console.WriteLine();
        
        // Dynamic
        
        BaseClass vbc = new BaseClass(); // 
        Console.Write("BaseClass vbc = new BaseClass(): ");
        vbc.DynamicMethod();
        BaseClass vbcdc = new DerivedClass();
        Console.Write("BaseClass vbcdc = new DerivedClass(): ");
        vbcdc.DynamicMethod();
        DerivedClass vdc = new DerivedClass();
        Console.Write("DerivedClass vdc = new DerivedClass(): ");
        vdc.DynamicMethod();
        Console.WriteLine("DVS det er dynamisk, da både vbcdc og vbc kalder først DynamicMethod i DerivedClass, og hvis ikke den eksistere der, kalder den DynamicMethod i BaseKlassen.");
        Console.WriteLine();
        
        // En liste af vehicles af en bil, cykel og færge, som hver især har en metode der afspiller en lyd, som er arvet fra en lignende metode i vehicle
        // For at kunne afspille den specifikke lyd fra hvert objekt, så skal enten:
        // Static method: hvert objekt laves (castes) om til datatypen den kom af, ellers kaldes den statiske metode i vehicle
        // Dynamic method: hvert objekt kan dynamisk afspille deres specifikke lyd, hvis metoden (override) eksisterer, ellers kaldes (virtual) metoden i vehicle
        

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


    // ARV \\
    // Baseklasse
    public class Vehicle
    {
        public int Year { get; set; } // Production year
        public string Model { get; set; }
        
        protected Vehicle(int year, string model)
        {
            Year = year;
            Model = model;
        }
        
        // Parameterless constructor chaining to set default values
        public Vehicle() : this(1994, "Unknown Model")
        {
            
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Model: {Model}, Year: {Year}");
        }
        
    }

    // ARV \\
    // Derived klasse
    public class Car : Vehicle
    {
        public int HorsePower { get; set; }

        // Constructor chaining to call the base class constructor
        public Car(string model, int year, int horsePower) : base(year, model)
        {
            HorsePower = horsePower;
        }

        // Additional constructor chaining within the derived class, default values for a Car object; no arg constructor
        public Car() : this("Unknown Model", DateTime.Now.Year, 65)
        {
        }

        public new void DisplayInfo()
        {
            base.DisplayInfo(); // Vi kalder base klassen (Vehicle) metoden DisplayInfo fra den derived klasse (Car)
            Console.WriteLine($"HorsePower: {HorsePower}");
        }

        // Additional method specific to cars
        public void Honk()
        {
            Console.WriteLine("Honk! Honk!");
        }
    }
    
    // STATIC VS DYNAMIC METHOD DISPATCH \\

    public class BaseClass
    {
        public void StaticMethod()
        {
            Console.WriteLine("Base - StaticMethod");
        }

        // Enable dynamic method dispatch with the keyword VIRTUAL
        // A virtual method specify that it may be replace with another at runtime
        public virtual void DynamicMethod()
        {
            Console.WriteLine("Base - Virtual DynamicMethod");
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public new void StaticMethod()
        {
            Console.WriteLine("Derived - StaticMethod");
        }

        // Her specifier vi med OVERRIDE at vi vil override vores VIRTUAL DynamicMethod i baseklassen.
        public override void DynamicMethod()
        {
            Console.WriteLine("Derived - Actual DynamicMethod");
        }
    }
}