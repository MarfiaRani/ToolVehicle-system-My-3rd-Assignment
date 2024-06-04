// See https://aka.ms/new-console-template for more information
using System;

//abstact class :It is a template definition of methods and variables
public abstract class ToolVehicle
{
    // Properties
    public int VehicleID { get; set; }
    public string RegNo { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; }

    // static Properties                            ======= static properties:  They are  properties shared across all instances of the class
    public static int TotalVehicles { get; set; }
    public static int TotalTaxPayingVehicles { get; set; }
    public static int TotalNonTaxPayingVehicles { get; set; }
    public static decimal TotalTaxCollected { get; set; }

    // Constructor for the vehicle
    public ToolVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice, string vehicleType)
    {
        VehicleID = vehicleID;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = basePrice;
        VehicleType = vehicleType;
        TotalVehicles++;
    }
    // Abstract method for paying tax
    public abstract void PayTax();

    // Method for passing without paying tax
    public void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;
    }
}
// the Child classes eg: Car class inherits the properties and methods of the parent class " ToolVehicle"
public class Car : ToolVehicle
{
    public Car(int vehicleID, string regNo, string model, string brand, decimal basePrice) : base(vehicleID, regNo, model, brand, basePrice, "Car")
    {
    }

    public override void PayTax()
    {
        decimal taxAmount = 2m; //total tax collected is incremented by 2.00.
        TotalTaxCollected += taxAmount;   //adds the taxAmount to the TotalTaxCollected
        TotalTaxPayingVehicles++;
    }
}

public class Bike : ToolVehicle
{
    public Bike(int vehicleID, string regNo, string model, string brand, decimal basePrice) : base(vehicleID, regNo, model, brand, basePrice, "Bike")
    {
    }

    public override void PayTax()
    {
        decimal taxAmount = 1m;
        TotalTaxCollected += taxAmount;
        TotalTaxPayingVehicles++;
    }
}

public class HeavyVehicle : ToolVehicle
{
    public HeavyVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice) : base(vehicleID, regNo, model, brand, basePrice, "HeavyVehicle")
    {
    }

    public override void PayTax()
    {
        decimal taxAmount = 4m;
        TotalTaxCollected += taxAmount;
        TotalTaxPayingVehicles++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Initialize static properties
        ToolVehicle.TotalVehicles = 0;
        ToolVehicle.TotalTaxPayingVehicles = 0;
        ToolVehicle.TotalNonTaxPayingVehicles = 0;
        ToolVehicle.TotalTaxCollected = 0.0m;

        while (true)
        {
            Console.WriteLine("Tool Vehicle Tax Management System");
            Console.WriteLine("1. Enter your vehicle type and pay taxes for a vehicle");
            Console.WriteLine("2. Print  your ToolVehicle statistics");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter your vehicle type (C for Car, B for Bike, H for HeavyVehicle, O for Other): ");
                    char vehicleType = Convert.ToChar(Console.ReadLine());
                    switch (vehicleType)
                    {
                        case 'C':
                            Console.Write("Enter vehicle registration number: ");
                            string regNo = Console.ReadLine();
                            Console.Write("Enter vehicle model: ");
                            string model = Console.ReadLine();
                            Console.Write("Enter vehicle brand: ");
                            string brand = Console.ReadLine();
                            Console.Write("Enter vehicle base price: ");
                            decimal basePrice = Convert.ToDecimal(Console.ReadLine());

                            Car car = new Car(ToolVehicle.TotalVehicles + 1, regNo, model, brand, basePrice);
                            Console.Write("Do you want to pay tax? (1 for yes, 0 for no): ");
                            int payTax = Convert.ToInt32(Console.ReadLine());
                            if (payTax == 1)
                            {
                                car.PayTax();
                            }
                            else
                            {
                                car.PassWithoutPaying();
                            }
                            break;
                        case 'B':
                            Console.Write("Enter vehicle registration number: ");
                            regNo = Console.ReadLine();
                            Console.Write("Enter vehicle model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter vehicle brand: ");
                            brand = Console.ReadLine();
                            Console.Write("Enter vehicle base price: ");
                            basePrice = Convert.ToDecimal(Console.ReadLine());

                            Bike bike = new Bike(ToolVehicle.TotalVehicles + 1, regNo, model, brand, basePrice);
                            Console.Write("Do you want to pay tax? (1 for yes, 0 for no): ");
                            payTax = Convert.ToInt32(Console.ReadLine());
                            if (payTax == 1)
                            {
                                bike.PayTax();
                            }
                            else
                            {
                                bike.PassWithoutPaying();
                            }
                            break;
                        case 'H':
                            Console.Write("Enter vehicle registration number: ");
                            regNo = Console.ReadLine();
                            Console.Write("Enter vehicle model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter vehicle brand: ");
                            brand = Console.ReadLine();
                            Console.Write("Enter vehicle base price: ");
                            basePrice = Convert.ToDecimal(Console.ReadLine());

                            HeavyVehicle heavyVehicle = new HeavyVehicle(ToolVehicle.TotalVehicles + 1, regNo, model, brand, basePrice);
                            Console.Write("Do you want to pay tax? (1 for yes, 0 for no): ");
                            payTax = Convert.ToInt32(Console.ReadLine());
                            if (payTax == 1)
                            {
                                heavyVehicle.PayTax();
                            }
                            else
                            {
                                heavyVehicle.PassWithoutPaying();
                            }
                            break;
                        case 'O':
                            Console.Write("Enter vehicle registration number: ");
                            regNo = Console.ReadLine();
                            Console.Write("Enter vehicle model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter vehicle brand: ");
                            brand = Console.ReadLine();
                            Console.Write("Enter vehicle base price: ");
                            basePrice = Convert.ToDecimal(Console.ReadLine());

                            // Handle other vehicle type
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a valid option.");
                            break;
                    }
                    break;
                case 2:
                    if (ToolVehicle.TotalVehicles == 0)
                    {
                        Console.WriteLine("No vehicles have passed through the system yet.");
                    }
                    else
                    {
                        Console.WriteLine("Total Vehicles: " + ToolVehicle.TotalVehicles);
                        Console.WriteLine("Total Tax Paying Vehicles: " + ToolVehicle.TotalTaxPayingVehicles);
                        Console.WriteLine("Total Non Tax Paying Vehicles: " + ToolVehicle.TotalNonTaxPayingVehicles);
                        Console.WriteLine("Total Tax Collected: " + ToolVehicle.TotalTaxCollected);
                    }
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the Tool Vehicle Tax Management System. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }
}
