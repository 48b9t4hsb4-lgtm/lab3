using System;

class Package
{
    private readonly int number;
    private double weight;
    private string status;

    private static int count = 0;

    public Package(int number, double weight)
    {
        this.number = number;
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

    public override string ToString()
    {
        return $"Номер: {number}, Вага: {weight}, Статус: {status}";
    }
}
