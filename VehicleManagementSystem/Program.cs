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

                Vehicle vehicle = CreateVehicle(type, name, price, speed);
                if (vehicle != null)
                {
                    vehicleManager.AddVehicle(vehicle);
                    Console.WriteLine("Vehicle added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid vehicle type.");
                }
            }
            catch (FormatException){
                Console.WriteLine("Invalid input format. Please enter numeric values for price and speed.");
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static Vehicle CreateVehicle(string type, string name, double price, double speed){
            switch (type.ToLower())
            {
                case "car":
                    return new Car { Name = name, Price = price, Speed = speed };
                case "racecar":
                    return new RaceCar { Name = name, Price = price, Speed = speed };
                case "airplane":
                    return new Airplane { Name = name, Price = price, Speed = speed };
                case "cargoairplane":
                    return new CargoAirplane { Name = name, Price = price, Speed = speed };
                case "boat":
                    return new Boat { Name = name, Price = price, Speed = speed };
                case "luxuryyacht":
                    return new LuxuryYacht { Name = name, Price = price, Speed = speed };
                case "truck":
                    return new Truck { Name = name, Price = price, Speed = speed };
                case "train":
                    return new Train { Name = name, Price = price, Speed = speed };
                default:
                    return null;
            }
        }
        static void DisplayAllVehicles(VehicleManager vehicleManager){
            Vehicle[] vehicles = vehicleManager.GetAllVehicles();
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }
        static void CalculateTaxForAllVehicles(VehicleManager vehicleManager, TaxCalculator taxCalculator){
            Vehicle[] vehicles = vehicleManager.GetAllVehicles();
            foreach (var vehicle in vehicles)
            {
                double tax = taxCalculator.CalculateTax(vehicle);
                Console.WriteLine($"Tax for {vehicle.Name} ({vehicle.VehicleType}): {tax}");
            }
        }

        static void DisplayVehicleStatistics(VehicleManager vehicleManager, VehicleStatistics vehicleStatistics){
            Vehicle[] vehicles = vehicleManager.GetAllVehicles();
            Console.WriteLine($"Average Price: {vehicleStatistics.GetAveragePrice(vehicles)}");
            Console.WriteLine("Fastest Vehicles by Type:");
            var fastestVehicles = vehicleStatistics.GetFastestVehiclesByType(vehicles);
            foreach (var entry in fastestVehicles)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.Name} with speed {entry.Value.Speed}");
            }
            Console.WriteLine("Vehicle Count by Type:");
            var vehicleCount = vehicleStatistics.CountVehiclesByType(vehicles);
            foreach (var entry in vehicleCount)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
