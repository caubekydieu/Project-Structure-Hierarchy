using System;
using System.Linq;
using System.Collections.Generic;
using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.IndependentClasses
{
    public class VehicleStatistics
    {
        // Tính giá trung bình của tất cả phương tiện
        public double GetAveragePrice(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return 0;
                
            return vehicles.Average(v => v.Price);
        }
        
        // Tìm phương tiện nhanh nhất trong mỗi loại
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
        
        // Đếm số lượng mỗi loại phương tiện
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
        
        // Tìm tất cả xe tải có LoadCapacity > giá trị cho trước
        public Truck[] GetTrucksWithLoadCapacityGreaterThan(Vehicle[] vehicles, double minCapacity)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Truck[0];
                
            return vehicles
                .Where(v => v is Truck && ((Truck)v).LoadCapacity > minCapacity)
                .Cast<Truck>()
                .ToArray();
        }
        
        // Tìm tất cả phương tiện có tốc độ lớn hơn giá trị cho trước
        public Vehicle[] GetVehiclesFasterThan(Vehicle[] vehicles, double minSpeed)
        {
            if(vehicles == null || vehicles.Length == 0)
                return new Vehicle[0];
                
            return vehicles
                .Where(v => v.Speed > minSpeed)
                .ToArray();
        }
        
        // Tìm phương tiện đắt nhất
        public Vehicle GetMostExpensiveVehicle(Vehicle[] vehicles)
        {
            if(vehicles == null || vehicles.Length == 0)
                return null;
                
            return vehicles
                .OrderByDescending(v => v.Price)
                .First();
        }
        
        // Tính giá trung bình của mỗi loại phương tiện
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