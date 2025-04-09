using System;

namespace VehicleManagementSystem.Vehicles
{
    public class CargoAirplane : Airplane{
        public double CargoCapacity { get; set; }
        public CargoAirplane(){
            VehicleType = "Cargo Airplane";
        }
        
        public override double CalculateTax(){
            return 0.15 * Price;
        }
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.WriteLine("Cargo Capacity: " + CargoCapacity);
        }
    }
}