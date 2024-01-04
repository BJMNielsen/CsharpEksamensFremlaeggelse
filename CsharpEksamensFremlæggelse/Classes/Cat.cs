namespace CsharpEksamensFremlæggelse.Classes;

public class Cat
{
    public int Age { get; set; }
    public string Name { get; set; }

    public string[] Mus = new string[10];

    public Cat()
    {
        
    }

    public Cat(string name)
    {
        Name = name;
    }
    
}