namespace CsharpEksamensFremlæggelse.Part1Typer;

public class MainPart1
{
   
     public static void Run()
     {
          //   VALUE TYPER   \\ --------------------------------------------------------------------------
          Console.WriteLine("------------VALUE TYPES-----------------------------------------------------------------------------------------------");
          // Lagres direkte på stacken
          // Value typer opbevarer data direkte i deres hukommelsesområde.
          // Almindelige eksempler er de indbyggede datatyper som int, double, char, float og bool.
          // Kopiadfærd: Ændringer i den nye variabel påvirker ikke den oprindelige variabel.
          
          int a = 10;
          Console.WriteLine("Her er a = " + a);
          
          int b = a; // kopiere værdien fra a til b.
          Console.WriteLine("Her er b = " + b);
          
          a = 20; // Ændrer ikke b, da b har sin egen kopi
          Console.WriteLine("Her er a = " + a);
          Console.WriteLine("Her er b stadig = " + b);
          Console.WriteLine();
          
          // Dvs at a og b PEGER ikke på hinanden, derfor ændres b's værdi ikke når a's ændres. De er bare kopier.
          
          
          
          //   REFERENCE TYPER   \\ --------------------------------------------------------------------------
          Console.WriteLine("------------REFERENCE TYPES-----------------------------------------------------------------------------------------------");
          // Lagres på heapen
          // Reference typer opbevarer en reference (eller en pointer) til den faktiske data i hukommelsen.
          // Klasser, arrays, delegates og interfaces er eksempler på reference typer.

          Person person1 = new Person { Navn = "Alice" };
          Console.WriteLine($"Her er person1's navn: {person1.Navn}");
          
          Person person2 = person1; // Kopiere reference
          Console.WriteLine($"Her er person2's navn: {person2.Navn}");
          
          person1.Navn = "Bob";  // Fordi det er en reference, ændre den også person 2.
          Console.WriteLine($"Nu er person1's navn: {person1.Navn}");
          Console.WriteLine($"Nu er person2's navn OGSÅ: {person2.Navn} fordi den referere til person1 som blev ændret til Bob");
          Console.WriteLine();
          // Kopiadfærd: Når en referencetype tildeles til en anden variabel, kopieres kun referencen.
          // Begge variabler refererer nu til de samme data på heapen, og ændringer via den ene variabel vil afspejles i den anden.

          
          //   Operator Overload   \\ --------------------------------------------------------------------------
          Console.WriteLine("------------OPERATOR OVERLOAD-----------------------------------------------------------------------------------------------");
          //  Gør det muligt at bruge standardoperatorer (+, -, *, %) med dine egne klasser og strukturer, hvilket kan øge læsbarheden og skriveeffektiviteten af koden
          
          Point p1 = new Point(1, 2);
          Point p2 = new Point(3, 4);

          Point p3 = Point.PlusPoint(p1, p2); // Sådan ville metoden se ud uden overload.
          Point point3 = p1 + p2; // Bruger den overbelastede + operator

          // her får man et nyt point objekt med summen af de 2 foriges.
          Console.WriteLine($"p1: X = {p1.X}, Y = {p1.Y}");
          Console.WriteLine($"p2: X = {p2.X}, Y = {p2.Y}");
          Console.WriteLine($"Sum af p1 og p2 i et nyt punkt3: X = {point3.X}, Y = {point3.Y}"); // Output: Sum: X = 4, Y = 6
          Console.WriteLine();
          
          
          //   METHOD PARAMETERS: IN / OUT / REF   \\ --------------------------------------------------------------------------
          Console.WriteLine("------------METHOD PARAMETERS: IN / OUT / REF-----------------------------------------------------------------------------------------------");
          
          int inArg = 1;  // ¨in" read-only og kan ikke ændres i metoden
          int outArg;     // "out" skal initialiseres i metoden før de returneres
          int refArg = 3; // "ref" argument gives til metoden som reference, dvs hvis metoden ændre den, vil den originale variabel også ændres.
          
          Console.WriteLine($"Her er inArg før: {inArg}");
          Console.WriteLine($"Her er refArg før: {refArg}");
          Console.WriteLine();
          
          MainPart1 mainPart1 = new MainPart1();
          mainPart1.EksempelMetode(inArg, out outArg, ref refArg);
          Console.WriteLine($"Her er inArg efter metodekald: {inArg}");
          Console.WriteLine($"Her er outArg efter metodekald: {outArg}");
          Console.WriteLine($"Her er refArg efter metodekald: {refArg}");
          Console.WriteLine();
          
          
          //   METHOD PARAMETERS: Positional / Named / Default   \\ --------------------------------------------------------------------------
          Console.WriteLine("------------METHOD PARAMETERS: Positional / Named / De fault -----------------------------------------------------------------------------------------------");

          // Positional parameter call
          mainPart1.EksempelMetode2("Hej", "Hans"); // Argumenter sat i rækkefølge ud efter signatur
          
          // Named parameter call
          mainPart1.EksempelMetode2(secondParam:"Bo", firstParam:"Farvel"); // specificere argumenter ud efter navne på parametrene, frihed i rækkefølge
          
          // Default parameter call
          mainPart1.EksempelMetode2(); // sat default argumenter.
     }

     class Person
     {
          public string Navn { get; set; }
     }
     

     public class Point
     {
          public int X { get; set; }
          public int Y { get; set; }

          public Point(int x, int y)
          {
               X = x;
               Y = y;
          }
          
          // Specialiseret metode - Overloading af + operatoren
          public static Point operator +(Point p1, Point p2)
          {
               // sådan ville man skrive det uden operator overload.
               return new Point(p1.X + p2.X, p1.Y + p2.Y);
          }

          public static Point PlusPoint(Point p1, Point p2)
          {
               return new Point(p1.X + p2.X, p1.Y + p2.Y);
          }
     }

     void EksempelMetode(in int inParameter, out int outParameter, ref int refParameter)
     {
          // inParameter kan ikke ændres
          outParameter = 5; // SKAL initialiseres
          refParameter += inParameter;
     }

     // Her har vi givet metoden default værdier til firstParam og secondParam
     void EksempelMetode2(string firstParam = "Hello", string secondParam = "World")
     {
          Console.WriteLine($"{firstParam} {secondParam}");
     }
}