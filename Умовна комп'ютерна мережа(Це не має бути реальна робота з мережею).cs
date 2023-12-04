using System;

// Інтерфейс для підключення до мережі
public interface IConnectable
{
    void Connect(Компютер компютер);
    void Disconnect(Компютер компютер);
    void TransmitData(Компютер отримувач, string data);
}

// Базовий клас Комп'ютер
public class Компютер
{
    public string IPАдреса { get; set; }
    public int Потужність { get; set; }
    public string ТипОС { get; set; }

    public Компютер(string ipАдреса, int потужність, string типОС)
    {
        IPАдреса = ipАдреса;
        Потужність = потужність;
        ТипОС = типОС;
    }
}

// Клас Сервер, який є комп'ютером та може бути з'єднаним з іншими пристроями
public class Сервер : Компютер, IConnectable
{
    public Сервер(string ipАдреса, int потужність, string типОС) : base(ipАдреса, потужність, типОС)
    {
    }

    public void Connect(Компютер компютер)
    {
        Console.WriteLine($"Сервер {IPАдреса} підключений до комп'ютера {компютер.IPАдреса}");
    }

    public void Disconnect(Компютер компютер)
    {
        Console.WriteLine($"Сервер {IPАдреса} відключений від комп'ютера {компютер.IPАдреса}");
    }

    public void TransmitData(Компютер отримувач, string data)
    {
        Console.WriteLine($"Сервер {IPАдреса} передає дані до комп'ютера {отримувач.IPАдреса}: {data}");
    }
}

// Клас РобочаСтанція
public class РобочаСтанція : Компютер, IConnectable
{
    public РобочаСтанція(string ipАдреса, int потужність, string типОС) : base(ipАдреса, потужність, типОС)
    {
    }

    public void Connect(Компютер компютер)
    {
        Console.WriteLine($"Робоча станція {IPАдреса} підключена до комп'ютера {компютер.IPАдреса}");
    }

    public void Disconnect(Компютер компютер)
    {
        Console.WriteLine($"Робоча станція {IPАдреса} відключена від комп'ютера {компютер.IPАдреса}");
    }

    public void TransmitData(Компютер отримувач, string data)
    {
        Console.WriteLine($"Робоча станція {IPАдреса} передає дані до комп'ютера {отримувач.IPАдреса}: {data}");
    }
}

// Клас Маршрутизатор
public class Маршрутизатор : Компютер, IConnectable
{
    public Маршрутизатор(string ipАдреса, int потужність, string типОС) : base(ipАдреса, потужність, типОС)
    {
    }

    public void Connect(Компютер компютер)
    {
        Console.WriteLine($"Маршрутизатор {IPАдреса} підключений до комп'ютера {компютер.IPАдреса}");
    }

    public void Disconnect(Компютер компютер)
    {
        Console.WriteLine($"Маршрутизатор {IPАдреса} відключений від комп'ютера {компютер.IPАдреса}");
    }

    public void TransmitData(Компютер отримувач, string data)
    {
        Console.WriteLine($"Маршрутизатор {IPАдреса} передає дані до комп'ютера {отримувач.IPАдреса}: {data}");
    }
}

// Клас Мережа для моделювання взаємодії між комп'ютерами
public class Мережа
{
    public static void Main()
    {
        Сервер сервер1 = new Сервер("192.168.1.1", 8, "Windows Server");
        РобочаСтанція робочаСтанція1 = new РобочаСтанція("192.168.1.2", 4, "Windows 10");
        Маршрутизатор маршрутизатор1 = new Маршрутизатор("192.168.1.254", 6, "RouterOS");

        сервер1.Connect(робочаСтанція1);
        робочаСтанція1.TransmitData(сервер1, "Hello from workstation!");
        маршрутизатор1.Connect(сервер1);
        сервер1.TransmitData(робочаСтанція1, "Data from server to workstation");
        робочаСтанція1.Disconnect(сервер1);
    }
}
