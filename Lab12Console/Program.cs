using ClassLibraryLab10;

namespace Lab12;

internal class Program
{
    static Random rnd = new Random();

    static void Main()
    {
        var list = new List<CelestialBody>(5);
        list.PrintList();

        var body = new CelestialBody(new IdNumber(1), "БЕБРА", 300, 500);
        list.AddAt(body, 3);
        Console.WriteLine();
        list.PrintList();

        list.RemoveAfter(body);
        Console.WriteLine();
        list.PrintList();

        var list2 = (List<CelestialBody>)list.Clone();

        list2.AddAt(body, 4);

        Console.WriteLine();
        list.PrintList();
        Console.WriteLine();
        list2.PrintList();
    }
}

