using System;
using System.Linq;
using System.Collections.Generic;
using VehicleManagementSystem.Vehicles;
namespace VehicleManagementSystem.IndependentClasses
{
    public class VehicleStatistics
    {
        public double GetAveragePrice(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return 0;
                
            return vehicles.Average(v => v.Price);
        }
        
        public Dictionary<string, Vehicle> GetFastestVehiclesByType(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Dictionary<string, Vehicle>();
                
            return vehicles
                .GroupBy(v => v.VehicleType)
                .ToDictionary(
                    group => group.Key,
                    group => group.OrderByDescending(v => v.Speed).First()
                );
        }
        public Dictionary<string, int> CountVehiclesByType(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Dictionary<string, int>();
                
            return vehicles
                .GroupBy(v => v.VehicleType)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );
        }
        public Truck[] GetTrucksWithLoadCapacityGreaterThan(Vehicle[] vehicles, double minCapacity)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Truck[0];
                
            return vehicles
                .Where(v => v is Truck && ((Truck)v).LoadCapacity > minCapacity)
                .Cast<Truck>()
                .ToArray();
        }
        

        public Vehicle[] GetVehiclesFasterThan(Vehicle[] vehicles, double minSpeed)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Vehicle[0];
                
            return vehicles
                .Where(v => v.Speed > minSpeed)
                .ToArray();
        }
        
        public Vehicle GetMostExpensiveVehicle(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return null;
                
            return vehicles
                .OrderByDescending(v => v.Price)
                .First();
        }
        
        public Dictionary<string, double> GetAveragePriceByType(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Dictionary<string, double>();
                
            return vehicles
                .GroupBy(v => v.VehicleType)
                .ToDictionary(
                    group => group.Key,
                    group => group.Average(v => v.Price)
                );
        }
    }
} 