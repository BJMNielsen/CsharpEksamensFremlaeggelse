using System.Collections;

namespace CsharpEksamensFremlæggelse.Part3Datatyper;

public class MainPart3
{
    public static void Run()
    {
        // COLLECTIONS \\  ----------------------------------------------------------------------------------------------------------------------------

        // C# tilbyder en række forskellige collections via System.Collections og System.Collections.Generic

        // NON-Generic Collections (System.Collections) LESS TYPESAFE
        Console.WriteLine(
            "------------COLLECTIONS----------------------------------------------------------------------------------------------------------------------------");
        ArrayList
            nonGenericCollections =
                new ArrayList
                {
                    "ArrayList", "Queue", "Stack", 1, 5.5
                }; // ArrayList er mindre typesafe, og kan opbevare elementer af hvilken som helst type.

        // QUEUE
        // Queue: En FIFO (First-In-First-Out) samling. Elementer tilføjes i den ene ende og fjernes fra den anden.
        Queue myQueue = new Queue();

        // Enqueue elements to the queue
        myQueue.Enqueue("Alice");
        myQueue.Enqueue("Bob");
        myQueue.Enqueue("Charlie");

        // Dequeue elements from the queue
        while (myQueue.Count > 0)
        {
            string person = (string)myQueue.Dequeue();
            Console.WriteLine($"{person} has been served/Dequeued.");
        }

        Console.WriteLine(
            "----------------------------------------------------------------------------------------------------------------------------");

        // STACK
        // Stack: En LIFO (Last-In-First-Out) samling. Det sidste element, der er tilføjet, er det første, der bliver fjernet. Tænk stablede tallerkener/vægte.

        Stack myStack = new Stack();

        // Push elements onto the stack
        myStack.Push("Alice");
        myStack.Push("Bob");
        myStack.Push("Charlie");

        // Pop elements from the stack
        while (myStack.Count > 0)
        {
            string person = (string)myStack.Pop();
            Console.WriteLine($"{person} has been Popped");
        }

        Console.WriteLine(
            "----------------------------------------------------------------------------------------------------------------------------");


        // Generic Collections (System.Collections.Generic) TYPESAFE
        List<string> genericCollections = new List<string>
            { "List<T>", "Dictionary<Tkey, TValue>", "HashSet<T>", "Queue<T>", "Stack<T>", "LinkedList<T>" };
        // List er dynamisk størrelse, dvs du kan fjerne og adde til listen.

        Dictionary<string, string> landeKoder = new Dictionary<string, string> { { "DK", "Danmark" }, { "US", "USA" } };
        // string land = landeKoder["DK"]; // Finder værdien for nøglen DK
        // Console.WriteLine(land);

        // Brug TryGetValue for at undgå KeyNotFoundException
        string land;
        if (landeKoder.TryGetValue("DK", out land)) //
        {
            Console.WriteLine($"Landet er: {land}");
        }
        else
        {
            Console.WriteLine("Nøglen findes ikke i ordbogen.");
        }

        Console.WriteLine(
            "------------------ARRAYS ----------------------------------------------------------------------------------------------------------");


        // Arrays \\  ----------------------------------------------------------------------------------------------------------------------------

        // Arrays er fixed i størrelsen, og index baseret fra 0.

        // Declare with size
        int[] oddNumbers = new int[5];
        string[] cities = new String[3];

        // Initialize with size
        int[] evenNumbers = new int[5] { 2, 4, 6, 8, 10 };
        string[] cities2 = new string[3] { "Copenhagen", "New York", "Paris" };

        // Initialize without type
        int[] numbers = { 1, 3, 6, 9 };
        string[] cities3 = { "Brussel", "Amsterdam", "London" };

        // Tildeling af værdier
        int[] exampleArray = new int[3];

        exampleArray[0] = 10;
        exampleArray[1] = 20;
        exampleArray[2] = 30;

        // Adgang til elementer
        int førsteTal = exampleArray[0];

        // Iteration over et array
        foreach (var element in exampleArray)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine();

        // Arrays kan også bruge LINQ extension methods
        int sum = exampleArray.Sum();
        int max = exampleArray.Max();
        int min = exampleArray.Min();
        double average = exampleArray.Average();

        // Arrays har indbyggede static metoder

        // Sort
        int[] arr = { 5, 3, 2, 4, 1 };
        Array.Sort(arr); // arr er nu {1, 2, 3, 4, 5}
        Console.WriteLine("Sorted array: " + string.Join(" ", arr)); // Joins all numbers with a space and prints them

        // Length
        Console.WriteLine("Array length: " + arr.Length); // 5

        // Reverse
        Array.Reverse(arr); // Sort array in descending order // arr er nu {5, 4, 3, 2, 1}
        Console.WriteLine("Reverse sorting: " + string.Join(" ", arr));

        // Copy
        int[] copy = new int[5];
        Array.Copy(arr, copy, 5); // Copy arr array to copy
        Console.WriteLine("Copy array: " + string.Join(" ", copy));

        Console.WriteLine(
            "------------------ MULTI ARRAYS----------------------------------------------------------------------------------------------------------");


        // MULTIDIMENSIONAL ARRAYS
        // 2 typer, jaggeed og multi

        // Jagged (Each inner array must be initialized)
        // Each inner array can be different lengths

        int[][] jaggedArray = new int[3][]
        {
            new int[] { 1, 2, 3 }, // Row 0 with 3 elements
            new int[] { 4, 5 }, // Row 1 with 2 elements
            new int[] { 6 } // Row 2 with 1 element
        };
        Console.WriteLine("Jagged Array");

        // Access using two square brackets
        Console.WriteLine("First number is " +
                          jaggedArray[0][0]); // første array, første tal. Første række, første kolonne.
        // Print the jagged array
        for (int i = 0; i < jaggedArray.Length; i++) // Iterate over rows
        {
            for (int j = 0; j < jaggedArray[i].Length; j++) // Iterate over elements in each row
            {
                Console.Write(jaggedArray[i][j] + " ");
            }

            Console.WriteLine(); // New line for each row
        }

        Console.WriteLine();

        // MULTI (
        // Each inner array must be same lengths
        int[,] multiArray = new int[2, 3]
        {
            { 1, 2, 3 }, // Row 0
            { 4, 5, 6 } // Row 1
        };
        Console.WriteLine("Multi Array");

        // Access using commas
        Console.WriteLine("Second number is " +
                          multiArray[0, 1]); // første array, første tal. Første række, første kolonne.

        // print the multi array
        for (int i = 0; i < multiArray.GetLength(0); i++) // Iterate over rows
        {
            for (int j = 0; j < multiArray.GetLength(1); j++) // Iterate over columns
            {
                Console.Write(multiArray[i, j] + " ");
            }

            Console.WriteLine(); // New line for each row
        }

        Console.WriteLine(
            "----------------INDEXES------------------------------------------------------------------------------------------------------------");


        // INDEXES \\  ----------------------------------------------------------------------------------------------------------------------------
        // Fordelen ved at bruge indexers er, at du kan tilgå elementer i en klasse med en array-lignende syntaks,
        // hvilket gør det mere intuitivt og reducerer behovet for at eksponere interne datastrukturer.
        // Det gør også koden mere elegant og nemmere at læse.

        TestIndexClass testIndex = new TestIndexClass();
        testIndex[0] = 1; // Sætter værdien ved index 0
        testIndex.Tal[1] = 2; // Sådan ser det ud uden indexer

        int værdi = testIndex[0];
        int værdi2 = testIndex[1];

        // Læser værdien ved index 0
        Console.WriteLine(værdi + " " + værdi2);

        // dvs vi slipper for at skille sige int værdi = testIndex.tal[0], og kan i stedet bare skrive int værdi = testIndex[0], eller testIndex.tal[0] = 1


        Console.WriteLine(
            "------------------GENERICS & REIFICATION----------------------------------------------------------------------------------------------------------");
        // Generics og Re-ification \\  ----------------------------------------------------------------------------------------------------------------------------

        // Generics i C# er et programmeringskoncept, som tillader udviklere at skrive kode, der er uafhængig af en bestemt datatype.
        // Det betyder, at du kan skabe en klasse, en metode, en interface eller en delegate, som kan arbejde med enhver datatype, du angiver senere.
        // Generics øger kodegenbrug, type-sikkerhed og ydeevne.

        // RE-IFICATION. Forestil dig, at du har en liste af tal. I et sprog uden reification, når du ser på listen, ved du bare, at det er en liste af "noget"
        // - men ikke nødvendigvis at det er tal. I C#, med reification, når du ser på listen, ved du, at det er en liste af tal. C# husker typen.
        // Reficication sikre at typeinformation bevares og er tilgængelig ved runtime.


        // Anvendelse af GenericList
        // Her med String
        var list = new GenericList<string>(5);
        list.Add("Lars");
        list.Add("Bob");
        string item = list.GetItem(1); // item vil være "Bob"
        int amountOfItems = list.Count; // dette vil give 2, som i at der er to navne i listen

        // Her med Int
        var list2 = new GenericList<int>(4);
        list2.Add(12);
        list2.Add(5);
        int itemInt = list2.GetItem(0);
    }

    class TestIndexClass
    {
        private int[] tal = new int[5]; // Intern privat array

        public int[] Tal
        {
            get { return tal; }
            set { tal = value; }
        }

        public int this[int index] // Indexer definition (TextIndexClass[0] fx)
        {
            get { return tal[index]; } // Henter værdien fra 'tal' på positionen 'index'
            set { tal[index] = value; } // Sætter værdien på positionen 'index' i 'tal'
        }
    }

    public class GenericList<T>
    {
        private T[] _items;
        private int _count; // count er default 0

        public int Count
        {
            get { return _count; }
        }

        public GenericList(int initialSize)
        {
            // items bliver sat til et tomt array der har en initial størrelse og kan indholde T (generic) type, ud efter hvad objektet af klassen blev initializeret med
            _items = new T[initialSize];
        }

        public void Add(T item)
        {
            _items[_count] =
                item; // tilføjer et item med typen T ud fra hvilket antal items vi er på, som er 0 fra første gang
            _count++;
        }

        public T GetItem(int index)
        {
            return _items[index];
        }
    }
}