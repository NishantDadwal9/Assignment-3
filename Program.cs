using System;

// Base class for all vehicles
public class Vehicle
{
    // Properties
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public double RentalPrice { get; set; }

    // Constructor
    public Vehicle(string model, string manufacturer, int year, double rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }

    // Method to display vehicle details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}, Manufacturer: {Manufacturer}, Year: {Year}, Rental Price: {RentalPrice}");
    }
}

// Car class inheriting from Vehicle
public class Car : Vehicle
{
    // Additional properties for Car
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission { get; set; }
    public bool Convertible { get; set; }

    // Constructor
    public Car(string model, string manufacturer, int year, double rentalPrice, int seats, string engineType, string transmission, bool convertible)
        : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }

    // Override DisplayDetails method to include Car specific details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}, Engine Type: {EngineType}, Transmission: {Transmission}, Convertible: {Convertible}");
    }
}

// Truck class inheriting from Vehicle
public class Truck : Vehicle
{
    // Additional properties for Truck
    public int Capacity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    // Constructor
    public Truck(string model, string manufacturer, int year, double rentalPrice, int capacity, string truckType, bool fourWheelDrive)
        : base(model, manufacturer, year, rentalPrice)
    {
        Capacity = capacity;
        TruckType = truckType;
        FourWheelDrive = fourWheelDrive;
    }

    // Override DisplayDetails method to include Truck specific details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capacity: {Capacity}, Truck Type: {TruckType}, Four Wheel Drive: {FourWheelDrive}");
    }
}

// Motorcycle class inheriting from Vehicle
public class Motorcycle : Vehicle
{
    // Additional properties for Motorcycle
    public int EngineCapacity { get; set; }
    public string FuelType { get; set; }
    public bool HasFairing { get; set; }

    // Constructor
    public Motorcycle(string model, string manufacturer, int year, double rentalPrice, int engineCapacity, string fuelType, bool hasFairing)
        : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = engineCapacity;
        FuelType = fuelType;
        HasFairing = hasFairing;
    }

    // Override DisplayDetails method to include Motorcycle specific details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Capacity: {EngineCapacity}, Fuel Type: {FuelType}, Has Fairing: {HasFairing}");
    }
}

// RentalAgency class
public class RentalAgency
{
    // Array to store fleet of vehicles
    private Vehicle[] Fleet { get; set; }

    // Property to track total revenue
    public double TotalRevenue { get; private set; }

    // Constructor
    public RentalAgency(int capacity)
    {
        Fleet = new Vehicle[capacity];
        TotalRevenue = 0;
    }

    // Method to add vehicle to fleet
    public void AddVehicle(Vehicle vehicle, int index)
    {
        Fleet[index] = vehicle;
    }

    // Method to remove vehicle from fleet
    public void RemoveVehicle(int index)
    {
        if (index >= 0 && index < Fleet.Length)
        {
            TotalRevenue += Fleet[index].RentalPrice; // Add rental price to revenue before removing
            Fleet[index] = null;
        }
    }

    // Method to rent vehicle
    public Vehicle RentVehicle(int index)
    {
        if (index >= 0 && index < Fleet.Length && Fleet[index] != null)
        {
            Vehicle rentedVehicle = Fleet[index];
            Fleet[index] = null;
            return rentedVehicle;
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Testing the implementation
        RentalAgency agency = new RentalAgency(10);

        Car car = new Car("SUV", "Toyota", 2022, 100, 5, "V6", "Automatic", false);
        Truck truck = new Truck("F-150", "Ford", 2020, 150, 1000, "Pickup", true);
        Motorcycle motorcycle = new Motorcycle("Ninja", "Kawasaki", 2021, 80, 1000, "Gasoline", true);

        agency.AddVehicle(car, 0);
        agency.AddVehicle(truck, 1);
        agency.AddVehicle(motorcycle, 2);

        Console.WriteLine("Vehicles in the fleet:");
        for (int i = 0; i < agency.Fleet.Length; i++)
        {
            if (agency.Fleet[i] != null)
            {
                agency.Fleet[i].DisplayDetails();
            }
        }

        Console.WriteLine("Renting out the first vehicle...");
        Vehicle rentedVehicle = agency.RentVehicle(0);
        if (rentedVehicle != null)
        {
            Console.WriteLine("Rented Vehicle Details:");
            rentedVehicle.DisplayDetails();
        }

        Console.WriteLine($"Total Revenue: {agency.TotalRevenue}");
    }
}
