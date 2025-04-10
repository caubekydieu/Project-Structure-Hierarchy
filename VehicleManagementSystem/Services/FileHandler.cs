using System;
using System.IO;
using VehicleManagementSystem.Vehicles;
using System.Collections.Generic;

namespace VehicleManagementSystem.Services
{
    public class FileHandler{
        private const string FilePath = "vehicles.txt";

        public void SaveVehiclesToFile(Vehicle[] vehicles)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var vehicle in vehicles)
                {
                    writer.WriteLine($"{vehicle.GetType().Name},{vehicle.Name},{vehicle.Price},{vehicle.Speed},{vehicle.VehicleType}");
                }
            }
        }
        public Vehicle[] LoadVehiclesFromFile(){
            List<Vehicle> vehicles = new List<Vehicle>();

            if (!File.Exists(FilePath))
                return vehicles.ToArray();

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 5)
                        continue;

                    string type = parts[0];
                    string name = parts[1];
                    double price = double.Parse(parts[2]);
                    double speed = double.Parse(parts[3]);
                    string vehicleType = parts[4];

                    Vehicle vehicle = CreateVehicle(type, name, price, speed, vehicleType);
                    if (vehicle != null)
                    {
                        vehicles.Add(vehicle);
                    }
                }
            }

            return vehicles.ToArray();
        }
        private Vehicle CreateVehicle(string type, string name, double price, double speed, string vehicleType){
            Vehicle vehicle = null;

            switch (type.ToLower())
            {
                case "car":
                    vehicle = new Car { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "racecar":
                    vehicle = new RaceCar { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "airplane":
                    vehicle = new Airplane { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "cargoairplane":
                    vehicle = new CargoAirplane { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "boat":
                    vehicle = new Boat { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "luxuryyacht":
                    vehicle = new LuxuryYacht { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "truck":
                    vehicle = new Truck { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                case "train":
                    vehicle = new Train { Name = name, Price = price, Speed = speed, VehicleType = vehicleType };
                    break;
                default:
                    Console.WriteLine($"Unknown vehicle type: {type}");
                    break;
            }

            return vehicle;
        }
    }
} 