using System;

public class Vehicle
{
    private string model;
    private string manufacturer;
    private int year;
    private decimal rentalPrice;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Manufacturer
    {
        get { return manufacturer; }
        set { manufacturer = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public decimal RentalPrice
    {
        get { return rentalPrice; }
        set { rentalPrice = value; }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Manufacturer: " + Manufacturer);
        Console.WriteLine("Year: " + Year);
        Console.WriteLine("Rental Price: " + RentalPrice);
    }
}

public class Car : Vehicle
{
    private int seats;
    private string engineType;
    private string transmission;
    private bool convertible;

    public int Seats
    {
        get { return seats; }
        set { seats = value; }
    }

    public string EngineType
    {
        get { return engineType; }
        set { engineType = value; }
    }

    public string Transmission
    {
        get { return transmission; }
        set { transmission = value; }
    }

    public bool Convertible
    {
        get { return convertible; }
        set { convertible = value; }
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Seats: " + Seats);
        Console.WriteLine("Engine Type: " + EngineType);
        Console.WriteLine("Transmission: " + Transmission);
        Console.WriteLine("Convertible: " + Convertible);
    }
}

public class Truck : Vehicle
{
    private string capacity;
    private string truckType;
    private bool fourWheelDrive;

    public string Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public string TruckType
    {
        get { return truckType; }
        set { truckType = value; }
    }

    public bool FourWheelDrive
    {
        get { return fourWheelDrive; }
        set { fourWheelDrive = value; }
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Capacity: " + Capacity);
        Console.WriteLine("Truck Type: " + TruckType);
        Console.WriteLine("Four Wheel Drive: " + FourWheelDrive);
    }
}

public class Motorcycle : Vehicle
{
    private int engineCapacity;
    private string fuelType;
    private bool hasFairing;

    public int EngineCapacity
    {
        get { return engineCapacity; }
        set { engineCapacity = value; }
    }

    public string FuelType
    {
        get { return fuelType; }
        set { fuelType = value; }
    }

    public bool HasFairing
    {
        get { return hasFairing; }
        set { hasFairing = value; }
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Engine Capacity: " + EngineCapacity);
        Console.WriteLine("Fuel Type: " + FuelType);
        Console.WriteLine("Has Fairing: " + HasFairing);
    }
}

public class RentalAgency
{
    public Vehicle[] fleet;
    private decimal totalRevenue;

    public RentalAgency(int capacity)
    {
        fleet = new Vehicle[capacity];
        totalRevenue = 0;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        for (int i = 0; i < fleet.Length; i++)
        {
            if (fleet[i] == null)
            {
                fleet[i] = vehicle;
                break;
            }
        }
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        for (int i = 0; i < fleet.Length; i++)
        {
            if (fleet[i] == vehicle)
            {
                fleet[i] = null;
                break;
            }
        }
    }

    public void RentVehicle(Vehicle vehicle)
    {
        for (int i = 0; i < fleet.Length; i++)
        {
            if (fleet[i] == vehicle)
            {
                fleet[i] = null;
                totalRevenue += vehicle.RentalPrice;
                break;
            }
        }
    }

    public decimal TotalRevenue
    {
        get { return totalRevenue; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car
        {
            Model = "Civic",
            Manufacturer = "Honda",
            Year = 2022,
            RentalPrice = 50,
            Seats = 5,
            EngineType = "Gasoline",
            Transmission = "Automatic",
            Convertible = false
        };

        Truck truck = new Truck
        {
            Model = "F-150",
            Manufacturer = "Ford",
            Year = 2021,
            RentalPrice = 80,
            Capacity = "Half-Ton",
            TruckType = "Pickup",
            FourWheelDrive = true
        };

        Motorcycle motorcycle = new Motorcycle
        {
            Model = "Ninja",
            Manufacturer = "Kawasaki",
            Year = 2023,
            RentalPrice = 30,
            EngineCapacity = 1000,
            FuelType = "Petrol",
            HasFairing = true
        };

        RentalAgency rentalAgency = new RentalAgency(10);
        rentalAgency.AddVehicle(car);
        rentalAgency.AddVehicle(truck);
        rentalAgency.AddVehicle(motorcycle);

        Console.WriteLine("Details of Vehicles in Fleet:");
        foreach (Vehicle vehicle in rentalAgency.fleet)
        {
            if (vehicle != null)
            {
                vehicle.DisplayDetails();
                Console.WriteLine();
            }
        }

        Console.WriteLine("Renting a vehicle...");
        rentalAgency.RentVehicle(truck);

        Console.WriteLine("Total Revenue: " + rentalAgency.TotalRevenue);
    }
}
