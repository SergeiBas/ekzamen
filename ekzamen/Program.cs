namespace ekzamen;

abstract class Vehicle(string licensePlate, string model, string year)
{
    public string LicensePlate {get; set;} = licensePlate;
    public string Model  {get; set;} = model;
    public string Year  {get; set;} = year;

    public virtual void RunRoute()
    {
        Console.Write($"Автобус з номерним знаком {LicensePlate}, модель {Model}, {Year} року випуску, виконує ");
    }

    public virtual void Service()
    {
        Console.Write($"Обслуговування автобусу з номерним знаком {LicensePlate}, модель {Model}, {Year} року випуску, включає ");
    }
}

class CityBus(string licensePlate, string model, string year) : Vehicle(licensePlate, model, year)
{
    public override void RunRoute()
    {
        base.RunRoute();
        Console.WriteLine("приміські маршрути");
    }

    public override void Service()
    {
        base.Service();
        Console.WriteLine("перевірку гальм і шин");
    }
}

class TouristBus(string licensePlate, string model, string year) : Vehicle(licensePlate, model, year)
{
    public override void RunRoute()
    {
        base.RunRoute();
        Console.WriteLine("довгі міжміські рейси");
    }

    public override void Service()
    {
        base.Service();
        Console.WriteLine("перевірку кондиціонера та сидінь");
    }
}

class Minibus(string licensePlate, string model, string year) : Vehicle(licensePlate, model, year)
{
    public override void RunRoute(){
        base.RunRoute();
        Console.WriteLine("гнучкі маршрути на замовлення");
    }
    
    public override void Service(){
        base.Service();
        Console.WriteLine("перевірку паливної системи");
    }
}

class FleetManager
{
    private List<Vehicle> _vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }

    public void RunAllRoutes()
    {
        foreach (var vehicle in _vehicles)
        {
            vehicle.RunRoute(); 
        }
    }

    public void ServiceAllVehicles()
    {
        foreach (var vehicle in _vehicles)
        {
            vehicle.Service(); 
        }
    }
}


class Program
{
    static void Main()
    {
        // new CityBus("CA0010HH", "BOGDAN1", "2003").RunRoute();
        // new CityBus("CA0010HH", "BOGDAN1", "2003").Service();
        //
        // new TouristBus("CA0001II", "Mercedes T2", "2010").RunRoute();
        // new TouristBus("CA0001II", "Mercedes T2", "2010").Service();
        //
        // new Minibus("KA1231AA", "VW T5", "2015").RunRoute();
        // new Minibus("KA1231AA", "VW T5", "2015").Service();
        FleetManager fleetManager = new FleetManager();

        fleetManager.AddVehicle(new CityBus("CA0010HH", "BOGDAN1", "2003"));
        fleetManager.AddVehicle(new TouristBus("CA0001II", "Mercedes T2", "2010"));
        fleetManager.AddVehicle(new Minibus("KA1231AA", "VW T5", "2015"));

        Console.WriteLine("===== Виконання рейсів =====");
        fleetManager.RunAllRoutes();

        Console.WriteLine("\n===== Технічне обслуговування =====");
        fleetManager.ServiceAllVehicles();
    }
}