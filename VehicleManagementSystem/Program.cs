using System;
using VehicleManagementSystem.Vehicles;
using VehicleManagementSystem.Services;
using VehicleManagementSystem.IndependentClasses;
using VehicleManagementSystem.Exceptions;
namespace VehicleManagementSystem{
    class Program{
        static void Main(string[] args){
            VehicleManager vehicleManager = new VehicleManager();
            FileHandler fileHandler = new FileHandler();
            TaxCalculator taxCalculator = new TaxCalculator();
            VehicleStatistics vehicleStatistics = new VehicleStatistics();

            try
            {
                // Load vehicles from file
                Vehicle[] vehicles = fileHandler.LoadVehiclesFromFile();
                foreach (var vehicle in vehicles)
                {
                    vehicleManager.AddVehicle(vehicle);
                }

                // menu
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Vehicle Management System");
                    Console.WriteLine("1. Add Vehicle");
                    Console.WriteLine("2. Display All Vehicles");
                    Console.WriteLine("3. Sort Vehicles by Price");
                    Console.WriteLine("4. Sort Vehicles by Speed");
                    Console.WriteLine("5. Calculate Tax for All Vehicles");
                    Console.WriteLine("6. Display Vehicle Statistics");
                    Console.WriteLine("7. Save and Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice){
                        case "1":
                            AddVehicle(vehicleManager);
                            break;
                        case "2":
                            DisplayAllVehicles(vehicleManager);
                            break;
                        case "3":
                            vehicleManager.SortVehiclesByPrice();
                            Console.WriteLine("Vehicles sorted by price.");
                            break;
                        case "4":
                            vehicleManager.SortVehiclesBySpeed();
                            Console.WriteLine("Vehicles sorted by speed.");
                            break;
                        case "5":
                            CalculateTaxForAllVehicles(vehicleManager, taxCalculator);
                            break;
                        case "6":
                            DisplayVehicleStatistics(vehicleManager, vehicleStatistics);
                            break;
                        case "7":
                            fileHandler.SaveVehiclesToFile(vehicleManager.GetAllVehicles());
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void AddVehicle(VehicleManager vehicleManager){
            try{
                Console.Write("Enter vehicle type (Car, RaceCar, Airplane, CargoAirplane, Boat, LuxuryYacht, Truck, Train): ");
                string type = Console.ReadLine();
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter speed: ");
                double speed = double.Parse(Console.ReadLine());

                Vehicle vehicle = null;
                switch (type.ToLower())
                {
                    case "car":
                        Console.Write("Enter model: ");
                        string model = Console.ReadLine();
                        Console.Write("Enter horse power: ");
                        string horsePower = Console.ReadLine();
                        vehicle = new Car { Name = name, Price = price, Speed = speed, Model = model, HorsePower = horsePower };
                        break;
                    case "racecar":
                        Console.Write("Enter model: ");
                        model = Console.ReadLine();
                        Console.Write("Enter horse power: ");
                        horsePower = Console.ReadLine();
                        Console.Write("Enter turbo boost: ");
                        double turboBoost = double.Parse(Console.ReadLine());
                        vehicle = new RaceCar { Name = name, Price = price, Speed = speed, Model = model, HorsePower = horsePower, TurboBoost = turboBoost };
                        break;
                    case "airplane":
                        Console.Write("Enter altitude: ");
                        double altitude = double.Parse(Console.ReadLine());
                        vehicle = new Airplane { Name = name, Price = price, Speed = speed, Altitude = altitude };
                        break;
                    case "cargoairplane":
                        Console.Write("Enter altitude: ");
                        altitude = double.Parse(Console.ReadLine());
                        Console.Write("Enter cargo capacity: ");
                        double cargoCapacity = double.Parse(Console.ReadLine());
                        vehicle = new CargoAirplane { Name = name, Price = price, Speed = speed, Altitude = altitude, CargoCapacity = cargoCapacity };
                        break;
                    case "boat":
                        Console.Write("Enter seating capacity: ");
                        double seatingCapacity = double.Parse(Console.ReadLine());
                        vehicle = new Boat { Name = name, Price = price, Speed = speed, SeatingCapacity = seatingCapacity };
                        break;
                    case "luxuryyacht":
                        Console.Write("Enter seating capacity: ");
                        seatingCapacity = double.Parse(Console.ReadLine());
                        Console.Write("Enter helipad (1 for yes, 0 for no): ");
                        double helipad = double.Parse(Console.ReadLine());
                        vehicle = new LuxuryYacht { Name = name, Price = price, Speed = speed, SeatingCapacity = seatingCapacity, Helipad = helipad };
                        break;
                    case "truck":
                        Console.Write("Enter load capacity: ");
                        double loadCapacity = double.Parse(Console.ReadLine());
                        vehicle = new Truck { Name = name, Price = price, Speed = speed, LoadCapacity = loadCapacity };
                        break;
                    case "train":
                        Console.Write("Enter number of units: ");
                        double units = double.Parse(Console.ReadLine());
                        vehicle = new Train { Name = name, Price = price, Speed = speed, Units = units };
                        break;
                    default:
                        Console.WriteLine("Invalid vehicle type.");
                        return;
                }

                if (vehicle != null)
                {
                    vehicleManager.AddVehicle(vehicle);
                    Console.WriteLine("Vehicle added successfully.");
                }
            }
            catch (FormatException){
                Console.WriteLine("Invalid input format. Please enter numeric values for price and speed.");
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayAllVehicles(VehicleManager vehicleManager){
            Console.WriteLine("\nSorted by Price:");
            Vehicle[] vehicles = vehicleManager.GetAllVehicles();
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }
        static void CalculateTaxForAllVehicles(VehicleManager vehicleManager, TaxCalculator taxCalculator){
            Console.WriteLine("\n=== Tax Calculations ===\n");
            Vehicle[] vehicles = vehicleManager.GetAllVehicles();
            double totalTax = 0;

            foreach (var vehicle in vehicles)
            {
                double tax = taxCalculator.CalculateTax(vehicle);
                totalTax += tax;
                Console.WriteLine($"Tax for {vehicle.Name} ({vehicle.VehicleType}): {tax:C}");
            }
            
            Console.WriteLine($"\nTotal Tax for All Vehicles: {totalTax:C}\n");
        }

        static void DisplayVehicleStatistics(VehicleManager vehicleManager, VehicleStatistics vehicleStatistics){
            Vehicle[] vehicles = vehicleManager.GetAllVehicles();
            Console.WriteLine("\n=== Vehicle Statistics ===");
            Console.WriteLine($"\nAverage Price: {vehicleStatistics.GetAveragePrice(vehicles):F1}");
            
            Console.WriteLine("\nFastest Vehicles by Type:");
            var fastestVehicles = vehicleStatistics.GetFastestVehiclesByType(vehicles);
            foreach (var entry in fastestVehicles)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.Name} with speed {entry.Value.Speed}");
            }
            
            Console.WriteLine("\nVehicle Count by Type:");
            var vehicleCount = vehicleStatistics.CountVehiclesByType(vehicles);
            foreach (var entry in vehicleCount)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.WriteLine();
        }
    }
}
