using System;
using VehicleManagementSystem.Vehicles;
using System.Linq;
using VehicleManagementSystem.IndependentClasses;

namespace VehicleManagementSystem.Services
{
    public class VehicleManager
    {
        private Vehicle[] vehicles;
        private int count;
        private const int DEFAULT_CAPACITY = 100;
        private readonly VehicleStatistics vehicleStatistics;
        private readonly VehicleComparer vehicleComparer;

        public VehicleManager()
        {
            vehicles = new Vehicle[DEFAULT_CAPACITY];
            count = 0;
            vehicleStatistics = new VehicleStatistics();
            vehicleComparer = new VehicleComparer();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null");

            if (count >= vehicles.Length)
            {
                Array.Resize(ref vehicles, vehicles.Length * 2);
            }

            vehicles[count++] = vehicle;
        }

        public Vehicle[] GetAllVehicles()
        {
            Vehicle[] result = new Vehicle[count];
            Array.Copy(vehicles, result, count);
            return result;
        }

        public int GetVehicleCount()
        {
            return count;
        }

        public void DisplayAllVehicles()
        {
            if (count == 0)
            {
                Console.WriteLine("No vehicles in the system.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nVehicle #{i + 1}:");
                vehicles[i].DisplayInfo();
                Console.WriteLine($"Tax: {vehicles[i].CalculateTax():C}");
            }
        }

        public void SortVehiclesByPrice()
        {
            if (count > 0)
            {
                Vehicle[] activeVehicles = new Vehicle[count];
                Array.Copy(vehicles, activeVehicles, count);
                
                VehicleComparer.SortByPrice(activeVehicles);
                
                Array.Copy(activeVehicles, vehicles, count);
            }
        }

        public void SortVehiclesBySpeed()
        {
            if (count > 0)
            {
                Vehicle[] activeVehicles = new Vehicle[count];
                Array.Copy(vehicles, activeVehicles, count);
                
                VehicleComparer.SortBySpeed(activeVehicles);
                
                Array.Copy(activeVehicles, vehicles, count);
            }
        }

        public void SortVehiclesByType()
        {
            if (count > 0)
            {
                Vehicle[] activeVehicles = new Vehicle[count];
                Array.Copy(vehicles, activeVehicles, count);
                
                VehicleComparer.SortByType(activeVehicles);
                
                Array.Copy(activeVehicles, vehicles, count);
            }
        }

        public void DisplayVehicleStatistics()
        {
            if (count == 0)
            {
                Console.WriteLine("No vehicles in the system to display statistics.");
                return;
            }

            var allVehicles = GetAllVehicles();
            
            Console.WriteLine("\n=== Vehicle Statistics ===");
            Console.WriteLine($"Total Vehicles: {count}");
            Console.WriteLine($"Average Price: {vehicleStatistics.GetAveragePrice(allVehicles):C}");
            
            Console.WriteLine("\nFastest Vehicles by Type:");
            var fastestVehicles = vehicleStatistics.GetFastestVehiclesByType(allVehicles);
            foreach (var entry in fastestVehicles)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.Name} (Speed: {entry.Value.Speed})");
            }

            Console.WriteLine("\nVehicle Count by Type:");
            var vehicleCount = vehicleStatistics.CountVehiclesByType(allVehicles);
            foreach (var entry in vehicleCount)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine("\nAverage Price by Type:");
            var avgPriceByType = vehicleStatistics.GetAveragePriceByType(allVehicles);
            foreach (var entry in avgPriceByType)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value:C}");
            }
        }

        public Vehicle[] GetVehiclesFasterThan(double minSpeed)
        {
            return vehicleStatistics.GetVehiclesFasterThan(GetAllVehicles(), minSpeed);
        }

        public Vehicle GetMostExpensiveVehicle()
        {
            return vehicleStatistics.GetMostExpensiveVehicle(GetAllVehicles());
        }

        public Truck[] GetTrucksWithLoadCapacityGreaterThan(double minCapacity)
        {
            return vehicleStatistics.GetTrucksWithLoadCapacityGreaterThan(GetAllVehicles(), minCapacity);
        }
    }
}