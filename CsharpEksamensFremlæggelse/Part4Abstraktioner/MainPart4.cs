namespace CsharpEksamensFremlæggelse.Part4Abstraktioner;

public class MainPart4
{
    public static void Run()
    {
        Console.WriteLine(
            "---------------------INTERFACE-------------------------------------------------------------------------------------------------");

        // En interface er en slags kontrakt eller blueprint for en klasse
        // Den indeholder DEKLARATIONER af properties, methods og fx events som skal implementeres af de klasser som benytter interfacet.

        // Car bruger vores IDrivable interface
        Car c1 = new Car();
        Console.WriteLine(c1.IsEngineRunning);
        c1.StartEngine(true);
        c1.StopEngine();
        Console.WriteLine();

        // Nu har jeg adgang til default metoden.
        IDriveable c2 = new Car();
        c2.defaultMethod();
        Console.WriteLine();

        // EXPLICIT IMPLEMENTATION
        c1.OpenDoor();
        // Explicit methods are only available when referencing as the interface, not class ie: "IDriveable c2 = new Car();", NOT "Car c1 = new Car();"
        c2.OpenDoor();
        Console.WriteLine();


        Console.WriteLine(
            "---------------------DELEGATES OG EVENT -------------------------------------------------------------------------------------------------");

        // Her laver vi et vegas objekt og køre vores event.
        LasVegas vegas = new LasVegas();

        // Her tager vi metoden fra sinatra og lægger ind i eventet  WhenShowStartsEvent som er knyttet til vores delegate WhenShowStarts.
        // Metoder der subscriber til eventet (SintraSing) skal have samme metode signatur som WhenShowStartsDelegate (i.e., ingen parametre og returns void).
        vegas.WhenShowStartsEvent += vegas.SinatraSing;
        vegas.WhenShowStartsEvent += vegas.SinatraGoodnight;

        // Nu kalder vi start show, der køre det event vi har lavet.
        vegas.StartShow();

        // Her fjerner vi en metode fra eventet
        vegas.WhenShowStartsEvent -= vegas.SinatraSing;
        vegas.StartShow();


        Console.WriteLine(
            "---------------------LAMBDAS -------------------------------------------------------------------------------------------------");
        //  the lambda expressions provide a way to define functionality on-the-fly, without the need for a separate method

        // To typer lamba BODIES: Expression eller Statement.

        // EXPRESSION lambda
        var expressionLambda = (int num) => num * 5; // Skrives på én linje

        // STATEMENT lambda
        var statementLambda = (int num) => // Én eller flere statement i { }
        {
            var sum = num * 5;
            return sum;
        };

        //  TWO TYPES OF LAMBDA

        // ACTION LAMBDA : Returner ikke noget (consume data)
        Action<int> actionLambda = (num) => Console.WriteLine($"Lars er {num} år gammel"); // 
        var actionLambda2 = (int num) => Console.WriteLine($"Lars er {num} år gammel"); // 

        // FUNC : Returner noget (generate result)
        Func<int, string> funcLambda = (num) => $"Vi konvertere {num} til en string"; // modtager int, returner string
        var funcLambda2 = (int num) => num * 5; // Skrives på én linje
        
        
        Console.WriteLine("Bruger en Func lambda (funcLambda2) til at give dets resultat til en Action lambda (actionLambda), for at udskrive:");
        actionLambda(funcLambda2(10));
        
        Console.WriteLine("------------------------------------------------------------------------\n");
        
        // HIGHER ORDER FUNCTIONS

        // Liste af byer
        List<string> cities = new List<string> { "Paris", "Copenhagen", "Mumbai" };

        // Her bruger vi lambda til at printe hver by i uppercase
        cities.ForEach(city => Console.WriteLine($"{city.ToUpper()}")); // Lambda tillader den her inline style som gør koden kompakt og nem at læse
        Console.WriteLine();

        // Her bruger vi en normal funktion til det. Kræver mere kode
        PrintCities(cities);
        Console.WriteLine();

        // 2 action lambdaer, void.
        Action<string> printStringToUpper = (string txt) => Console.WriteLine(txt.ToUpper());
        ;
        Action<string> printStringToLower = (string txt) => Console.WriteLine(txt.ToLower());

        // Her har vi lavet en higher order function der kan tage imod en ACTION<string> LAMBDA function som parameter
        PrintCities(cities, printStringToLower);
        PrintCities(cities, printStringToUpper);
        PrintCities(cities, txt => Console.WriteLine(txt.ToLower()));
        PrintCities(cities, (string txt) => Console.WriteLine(txt.ToUpper()));
        
    }


    // INTERFACE \\-------------------------------------------------------------------------------------------------
    // Definering af et interface
    public interface IDriveable
    {
        bool IsEngineRunning { get; set; } // Property deklaration
        void StartEngine(bool hasKey); // Just specifies the contract, NOT the implementation.
        void StopEngine(); // Just specifies the contract, NOT the implementation.
        void OpenDoor();

        void defaultMethod() // Kan bruges med implementationen af den klasse som bruger interfacet.
        {
            Console.WriteLine("Hey i'm a default method in the interface WITH an implementation.");
        }
    }

    // En klasse, der implementerer IDriveable
    public class Car : IDriveable
    {
        // Field til at gemme tilstanden af egenskaben
        private bool _isEngineRunning;

        // Property til Implementering af IsEngineRunning egenskaben
        public bool IsEngineRunning
        {
            get { return _isEngineRunning; }
            set { _isEngineRunning = value; }
        }

        public void StartEngine(bool hasKey)
        {
            if (hasKey)
            {
                Console.WriteLine("Starter nu motoren");
                IsEngineRunning = true;
            }
            else
                Console.WriteLine("Du har ingen nøgle, kan ikke starte");
        }

        public void StopEngine()
        {
            // Implementering af, hvordan man stopper motoren
            if (IsEngineRunning)
            {
                Console.WriteLine("The engine has been shut off");
            }
            else
            {
                Console.WriteLine("Engine is running already...");
                IsEngineRunning = false;
            }
        }

        // EXPLICIT IMPLEMENTATION
        // Does not require public, includes interface name, better readability. Mandatory if implementing 2 interfaces with same method signature.
        void IDriveable.OpenDoor() // explicitly name the method when implementing
        {
            Console.WriteLine("The door has now been opened using an explicit implemented method.");
        }

        public void OpenDoor()
        {
            Console.WriteLine("The door has been opened using the class' own method");
        }
    }

    // DELEGATES & EVENTS \\-------------------------------------------------------------------------------------------------
    public class LasVegas
    {
        // Vi laver en delegate, som skal bruges til eventet.
        // Delegate er en type der definere en specifik metode signatur (dvs return type og parametre).
        // Det er en slags placeholder/ reference for en metode. En slags variabel der indeholder en reference til en metode. It's like a variable for methods.
        // Når du bruger en delegate til et event, sikrer det, at alle metoder, der er knyttet til eventet, overholder denne signatur.
        public delegate void ShowStartDelegate();

        // Vi laver vores event med typen af den delegate vi lige har lavet, sådan en skal et event bruge for at virke.
        public event ShowStartDelegate? WhenShowStartsEvent;

        // Vi laver en StartShow metode, der køre vores event når vi kalder metoden.
        public void StartShow()
        {
            Console.WriteLine("Event start: Welcome Las Vegas");
            WhenShowStartsEvent
                ?.Invoke(); // invoke hvis den ikke er null. Når du kalder .Invoke() kalder du ALLE metoder der er subscribed til eventet.
            //WhenShowStartsEvent?.Invoke("Hello Las Vegas");
            Console.WriteLine("Event ending: Goodbye Las Vegas");
        }

        public void SinatraSing() // public void SinatraSing(string message)
        {
            Console.WriteLine("\t Frank Sinatra starts singing: New York, New York");
        }

        public void SinatraGoodnight()
        {
            Console.WriteLine("\t Goodnight everyone, Thanks for coming!");
        }
    }

    // LAMBDA \\-------------------------------------------------------------------------------------------------

    public static void PrintCities(List<string> cities)
    {
        foreach (var city in cities)
        {
            Console.WriteLine($"{city.ToUpper()}");
        }
    }

    public static void PrintCities(List<string> cities, Action<string> printCity)
    {
        Console.WriteLine("Do something BEFORE printing cities.");
        foreach (var city in cities)
        {
            printCity(city);
        }

        Console.WriteLine("Do something AFTER printing cities.");
    }
}