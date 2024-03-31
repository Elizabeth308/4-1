using System;

class Prog{
    static void Main()
    {
        OneDimensionMassive<int> intArray = new();
        OneDimensionMassive<double> doubleArray = new();
        Console.WriteLine("Enter the length of the array");
        int leng = int.Parse(Console.ReadLine());
        for(int i = 0; i < leng; i++)
        {
            Console.WriteLine("Enter the element");
            intArray.AddElement(int.Parse(Console.ReadLine()));
        }
        intArray.Print();
        Console.WriteLine("Enter the length of the array");
        leng = int.Parse(Console.ReadLine());
        for(int i = 0; i < leng; i++)
        {
            Console.WriteLine("Enter the element");
            doubleArray.AddElement(double.Parse(Console.ReadLine()));
        }
        doubleArray.Print();
        string command = Console.ReadLine();
        switch(command)
        {
            case "Delete":
                Console.WriteLine("Enter the index of the element you want to delete");
                intArray.DeleteElement(int.Parse(Console.ReadLine()));
                intArray.Print();
                Console.WriteLine("Enter the index of the element you want to delete");
                doubleArray.DeleteElement(int.Parse(Console.ReadLine()));
                doubleArray.Print();
                break;
            case "Sort":
                intArray.SortArray();
                intArray.Print();
                doubleArray.SortArray();
                doubleArray.Print();
                break;
            case "Maximum":
                Console.WriteLine("Max: " + intArray.Maximum());
                Console.WriteLine("Max: " + doubleArray.Maximum());
                break;
            case "Minimum":
                Console.WriteLine("Min: " + intArray.Minimum());
                Console.WriteLine("Min: " + doubleArray.Minimum());
                break;
            default:
                Console.WriteLine("Unknown command");
                break;
        }
    }
}