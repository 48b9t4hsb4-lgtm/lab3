using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Package p1 = new Package(1, 2.5);
        Package p2 = new Package(2);

        Console.WriteLine(p1);
        Console.WriteLine(p2);

        p1.ChangeStatus("В дорозі");
        p2.ChangeStatus("Доставлено");

        Console.WriteLine($"статус посилки 1: {p1.Status}");
        Console.WriteLine($"статус посилки 2: {p2.Status}");

        Console.WriteLine($"чи доставлена посилка 1: {p1.IsDelivered()}");
        Console.WriteLine($"чи доставлена посилка 2: {p2.IsDelivered()}");

        Console.WriteLine("Кількість посилок: " + Package.GetPackageCount());
    }
}