using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
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

        string writePath = (@"C:\Users\Asus\source\repos\lab4\JSON\write.json");
        string readPath = (@"C:\Users\Asus\source\repos\lab4\JSON\read.json");

        p2.SaveToJson(writePath);

        // зчитуємо дані з файлу та створюємо новий об'єкт
                Package loadedPackage = Package.LoadFromJson(readPath);

        if (loadedPackage != null)
        {
            Console.WriteLine("\nОбробка зчитаного файлу (Завдання 1)");
            Console.WriteLine("Початковий стан для зчитаної посилки:");
            Console.WriteLine(loadedPackage);

            Console.WriteLine($"Чи доставлена посилка: {loadedPackage.IsDelivered()}");

            Console.WriteLine($"Статус після зчитування файлу: {loadedPackage}");
        }

    }
}
