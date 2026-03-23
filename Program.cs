using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
class Package
{
    private readonly int number;
    private double weight;
    private string status;

    private static int count = 0;

    public Package(int number, double weight)
    {
        this.number = number ;
        this.weight = weight;
        this.status = "Створено";
        count++;
    }

    public Package(int number)
    {
        this.number = number;
        this.weight = 0;
        this.status = "Створено";
        count++;
    }

    private Package(int number, double weight, string status)
    {
        this.number = number;
        this.weight = weight;
        this.status = status;
        count++;
    }

    public double Weight
    {
        get { return weight; }
    }

    public string Status
    {
        get { return status; }
    }

    public void ChangeStatus(string newStatus)
    {
        status = newStatus;
    }

    public bool IsDelivered()
    {
        return status == "Доставлено";
    }

    public static int GetPackageCount()
    {
        return count;
    }

    public void SaveToJson(string filePath) // збереження у JSON
    {
        var dataToSave = new // створюємо анонімний об'єкт без визначеного класу, який містить тільки ті дані, які нам треба зберегти
        {
            Number = number,
            Weight = weight,
            Status = status
        };

        var options = new JsonSerializerOptions { WriteIndented = true }; //налаштування серіалізації(читабельність)
        string jsonString = System.Text.Json.JsonSerializer.Serialize(dataToSave, options); // конвертація анонімного об'єкту у текстовий рядок формату JSON

        // перевіряємо, чи існує папка, і створюємо її, якщо ні
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllText(filePath, jsonString); //записує згенерований рядок JSON у файл
        Console.WriteLine($"\nJSON Метод 1: Посилка {number} успішно збережена у файл:\n{filePath}");
    }




    public static Package LoadFromJson(string filePath) // завантаження з JSON
    {
        if (!File.Exists(filePath)) //перевірка чи існує файл за вказаним шляхом
        {
            Console.WriteLine($"\nERROR. Файл не знайдений для читання:\n{filePath}");
            Console.WriteLine("Перевір чи файл існує та чи він у форматі JSON.");
            return null;
        }

        string jsonString = File.ReadAllText(filePath);

        try
        {
            using JsonDocument doc = JsonDocument.Parse(jsonString); //парсимо JSON у структуру, з якою може працювати код
            JsonElement root = doc.RootElement; // отримуємо кореневий (головний) елемент JSON-документа, з якого будемо витягувати конкретні значення

            int loadedNumber = root.GetProperty("Number").GetInt32(); // get property - витягування з мого номеру цілого числа
            double loadedWeight = root.GetProperty("Weight").GetDouble();
            string loadedStatus = root.GetProperty("Status").GetString();

            Console.WriteLine($"\nJSON Метод 2: Дані успішно прочитані з файлу:\n{filePath}");
            return new Package(loadedNumber, loadedWeight, loadedStatus);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nПомилка читання JSON. Файл у неправильному форматі: {ex.Message}");
            return null;
        }
    }

    public override string ToString()
    {
        return $"Номер: {number}, Вага: {weight}, Статус: {status}";
    }
}
