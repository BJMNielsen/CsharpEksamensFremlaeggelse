namespace CsharpEksamensFremlæggelse.Part6FunctionalProgramming;

public class MainPart6
{
    public static void Run()
    {
        Console.WriteLine("---------------------FP CONSTRUCT------------------------------------------------\n");

        Console.WriteLine("---------------------RECORDS-----------------------------------------------------\n");

        // Records are a reference type that provides a simpler way to create immutable objects.
        // Inherently immutable. By default, records are immutable. Once their properties are set, they can't be changed.
        // Positional syntax auto generates constructor, Equals(Value based equality out the box), getHashCode and toString.
        // Fx brugt til DTO's eller hvis du henter data fra en databasen der ikke skal ændres er det godt at gemme i en record.

        // Creating a person
        var person1 = new Person("John", "Doe");

        // Value-based equality
        var person2 = new Person("John", "Doe");
        Console.WriteLine($"Equality: {person1.Equals(person2)}"); // Outputs: Equality: True

        // Deconstruction
        var (first, last) = person1;
        Console.WriteLine($"Deconstruction: {first} / {last}"); // Outputs: Deconstruction: John Doe

        // With-expression
        var person3 = person1 with { LastName = "Smith" };
        Console.WriteLine(
            $"With-expression: {person3.FirstName} {person3.LastName}"); // Outputs: With-expression: John Smith

        // Test af record method
        var person4 = new Person("Børge", "Morgensen");
        Console.WriteLine($"Full Name: {person4.FullName()}"); // Outputs: Full Name: John Doe
        Console.WriteLine();


        Console.WriteLine("---------------------LAMBDAS-----------------------------------------------------\n");

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

        Console.WriteLine(
            "Bruger en Func lambda (funcLambda2) til at give dets resultat til en Action lambda (actionLambda), for at udskrive:");
        actionLambda(funcLambda2(10)); // funcLambda2 returner en int, som actionLambda bruger

        Console.WriteLine("------------------------------------------------------------------------\n");


        // HIGHER ORDER FUNCTIONS

        // Liste af byer
        List<string> cities = new List<string> { "Paris", "Copenhagen", "Mumbai" };

        // Her bruger vi lambda til at printe hver by i uppercase
        cities.ForEach(city =>
            Console.WriteLine(
                $"{city.ToUpper()}")); // Lambda tillader den her inline style som gør koden kompakt og nem at læse
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
        Console.WriteLine();

        Console.WriteLine("---------------------TUPLES------------------------------------------------------\n");

        // Tuples are a simple and convenient way to group multiple values in a single object
        // They are useful when you need to return multiple values from a method or to pass multiple values around without creating a specific type

        // 3 different ways to create Tuples
        Tuple<int, string> tupleConstructor = new Tuple<int, string>(1, "Apple"); // constructor metoden
        Tuple<string, int, bool> tupleCreate = Tuple.Create("Hello", 23, true); // create metoden
        (string, int) tupleParentheses = ("Pear", 5); // parentes metoden

        Console.WriteLine();
        Console.WriteLine(
            $"Printing tupleConstructor: Item1 = {tupleConstructor.Item1} - Item2 = {tupleConstructor.Item2}");

        Console.WriteLine(
            $"Printing tupleCreate: Item1 = {tupleCreate.Item1} - Item2 = {tupleCreate.Item2} - Item3 = {tupleCreate.Item3}");

        Console.WriteLine(
            $"Printing tupleParentheses: Item1 = {tupleParentheses.Item1} - Item2 = {tupleParentheses.Item2}");
        Console.WriteLine();


        // Tuples er især nyttige til at returnere flere værdier af forskellige typer fra en metode
        string someTxt1 = "kiwi";
        string someTxt2 = "pear";
        // her har vi 2 variable, (int length, string upper), som vi deconstrutor vores tuple ud i.
        (int length, string upper) = CreateTupleWithLengthAndUppercase(someTxt1); // vi laver en touple
        Console.WriteLine();
        Console.WriteLine(
            $"Deconstructed int variable length har længden: {length} - Deconstructed string variabel upper: {upper}");

        // her gemmer vi tilgengæld tuple i en var.
        var tuplePear = CreateTupleWithLengthAndUppercase(someTxt2);
        Console.WriteLine();
        Console.WriteLine(
            $"Variable StringLength i Tuplen har længden: {tuplePear.StringLength} - String variabel StringUppercase i Tuplen: {tuplePear.StringUppercase}");
        Console.WriteLine();


        Console.WriteLine("---------------------PATTERN MATCHING--------------------------------------------\n");

        // Type Checking and Casting: Pattern matching allows you to check the type of an object and safely cast it in one operation.
        // Traditional methods would require type checking followed by explicit casting.

        // The is operator adds pattern matching to the if statement

        object obj = 123; // obj's type is unknown at compile time, It can hold any data type. 

        if (obj is string str)
        {
            // If object obj is a string, cast to a string and store in str.
            // This block is executed only if obj is a string.
            // obj is automatically cast to str (which is a string).
            Console.WriteLine($"String of length {str.Length}");
        }
        else if (obj is int i)
        {
            // This block is executed only if obj is an int.
            // obj is automatically cast to i (which is an int).
            Console.WriteLine($"Integer: {i}");
        }
        Console.WriteLine();
        // ... other type checks
        
        
       //  Example: Pattern Matching with a Switch STATEMENT
       // Switch statements don't return values but execute statements.
       // bruges hvis der skal executes distinktive blokke af kode.
       
       HandleObject(15);             // Outputs: Positive integer: 15
       HandleObject(-7);             // Outputs: Negative integer: -7
       HandleObject("Hello, World"); // Outputs: Long string: Hello, World
       HandleObject("Hi");           // Outputs: String: Hi
       HandleObject(null);           // Outputs: It's a null object
       HandleObject(3.14);           // Outputs: Unknown type

       
       // Switch EXPRESSION
       // Pattern Matching: Switch expressions are designed to work seamlessly with pattern matching, allowing for more complex and expressive cases.
       //  Each case in a switch expression directly yields a result, making it ideal for assignments or returning values based on various conditions
       
       int monthNr = DateTime.Now.Month;
       
       var month = monthNr switch
       {
           1 => "January", // Switch expressions return a value directly and are expressions, not statements
           2 => "February",
           _ => "Other"
       };
       


    }


    // Positional syntax
    public record Person(string FirstName, string LastName)
    {
        // Method to get the full name of the person
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
    // C# will automatically generate the following for this record:
    // A constructor that takes two parameters: FirstName and LastName.
    // A Deconstruct method to deconstruct the record back into two variables.
    //Value-based equality checks based on FirstName and LastName.


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

    // TUPLES \\-------------------------------------------------------------------------------------------------

    private static (int StringLength, string StringUppercase) CreateTupleWithLengthAndUppercase(string txt)
    {
        int lengthOfTxt = txt.Length;
        string uppercaseTxt = txt.ToUpper();
        return (lengthOfTxt, uppercaseTxt);
    }
    
    public static void HandleObject(object obj)
    {
        switch (obj)
        {
            case int i when i >= 0: // The case int i when i >= 0 checks if obj is a non-negative integer. If so, it is cast to i variable and processed.
                Console.WriteLine($"Positive integer: {i}");
                break;

            case int i: // The case int i handles all other integers (negative in this context).
                Console.WriteLine($"Negative integer: {i}");
                break;

            case string s when s.Length > 10: // The case string s when s.Length > 10 checks if obj is a string longer than 10 characters.
                Console.WriteLine($"Long string: {s}");
                break;

            case string s: // The case string s handles all other strings.
                Console.WriteLine($"String: {s}"); 
                break;

            case null:
                Console.WriteLine("It's a null object");
                break;

            default:
                Console.WriteLine("Unknown type");
                break;
        }
    }
}