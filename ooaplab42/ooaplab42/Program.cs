public interface AlarmC
{
    void Start();
    void Stop();
    void ToWake();
}

public interface AlarmCImpl
{
    void Ring();
    void Notify();
}

public class MechanicalAlarm : AlarmCImpl
{
    public void Ring()
    {
        Console.WriteLine("Mechanical alarm is ringing...");
    }

    public void Notify()
    {
        Console.WriteLine("Mechanical alarm is turned off...");
    }
}

public class ElectronicAlarm : AlarmCImpl
{
    public void Ring()
    {
        Console.WriteLine("Electronic alarm is playing...");
    }

    public void Notify()
    {
        Console.WriteLine("Electronic alarm is turned off...");
    }
}

public class Alarm : AlarmC
{
    private readonly AlarmCImpl alarmImpl;

    // Конструктор приймає реалізацію інтерфейсу AlarmCImpl (механічний або електронний будильник)
    public Alarm(AlarmCImpl alarmImpl)
    {
        this.alarmImpl = alarmImpl;
    }

    public void Start()
    {
        Console.WriteLine("Starting the alarm...");
        ToWake(); // Викликаємо метод для активації будильника
    }

    public void Stop()
    {
        Console.WriteLine("Stopping the alarm...");
    }

    public void ToWake()
    {
        alarmImpl.Ring(); // Викликаємо метод Ring на переданій реалізації будильника
        alarmImpl.Notify(); // Викликаємо метод Notify на переданій реалізації будильника
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        AlarmCImpl mechanicalImpl = new MechanicalAlarm(); // Створюємо реалізацію для механічного будильника
        AlarmCImpl electronicImpl = new ElectronicAlarm(); // Створюємо реалізацію для електронного будильника

        AlarmC mechanicalAlarm = new Alarm(mechanicalImpl); // Створюємо будильник з механічною реалізацією
        mechanicalAlarm.Start(); // Запускаємо механічний будильник
        mechanicalAlarm.Stop();  // Зупиняємо механічний будильник

        AlarmC electronicAlarm = new Alarm(electronicImpl); // Створюємо будильник з електронною реалізацією
        electronicAlarm.Start(); // Запускаємо електронний будильник
        electronicAlarm.Stop();  // Зупиняємо електронний будильник
    }
}
