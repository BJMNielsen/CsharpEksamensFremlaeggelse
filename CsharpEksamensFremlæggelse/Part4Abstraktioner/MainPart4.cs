namespace CsharpEksamensFremlæggelse.Part4Abstraktioner;

public class MainPart4
{
    public static void Run()
    {
        // INTERFACE \\-------------------------------------------------------------------------------------------------

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


        // DELEGATES & EVENTS \\-------------------------------------------------------------------------------------------------

        // Her laver vi et vegas objekt og køre vores event.
        LasVegas vegas = new LasVegas();

        // Her tager vi metoden fra sinatra og lægger ind i eventet  WhenShowStartsEvent som er knyttet til vores delegate WhenShowStarts.
        // Metoder der subscriber til eventet (SintraSing) skal have samme metode signatur som WhenShowStartsDelegate (i.e., ingen parametre og returns void).
        vegas.WhenShowStartsEvent += vegas.SinatraSing;
        vegas.WhenShowStartsEvent += vegas.SinatraGoodnight;

        // Nu kalder vi start show, der køre det event vi har lavet.
        vegas.StartShow();
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
            WhenShowStartsEvent?.Invoke(); // invoke hvis den ikke er null. Når du kalder .Invoke() kalder du ALLE metoder der er subscribed til eventet.
                //WhenShowStartsEvent?.Invoke("Hello Las Vegas");
            Console.WriteLine("Event ending: Goodbye Las Vegas");
        }

        public void SinatraSing() // // public void SinatraSing(string message)
        {
            Console.WriteLine("\t Frank Sinatra starts singing: New York, New York");
        }
        
        public void SinatraGoodnight()
        {
            Console.WriteLine("\t Goodnight everyone, Thanks for coming!");
        }
    }
}