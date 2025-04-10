using System;
using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.IndependentClasses
{
    public class TaxCalculator
    {
        public double CalculateTax(Vehicle vehicle){
            return vehicle.CalculateTax();
        }
        
        public double CalculateTotalTax(Vehicle[] vehicles){
            double totalTax = 0;
            foreach(var vehicle in vehicles)
            {
                totalTax += vehicle.CalculateTax();
            }
            return totalTax;
        }
        public double GetTaxRate(string vehicleType){
            switch(vehicleType.ToLower())
            {
                case "car":
                case "race car":
                    return 0.1;
                case "airplane":
                case "cargo airplane":
                    return 0.15;
                case "boat":
                case "luxury yacht":
                    return 0.05;
                case "truck":
                case "train":
                    return 0.2;
                default:
                    throw new ArgumentException("Unknown vehicle type");
            }
        }
    }
} 