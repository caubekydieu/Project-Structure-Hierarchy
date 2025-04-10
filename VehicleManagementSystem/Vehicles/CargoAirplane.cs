using System;
using VehicleManagementSystem.Exceptions;
namespace VehicleManagementSystem.Vehicles
{
    public class CargoAirplane : Airplane{
        private double _cargoCapacityValue;
        public double CargoCapacity
        { 
            get { return _cargoCapacityValue; }
            set
            {
                if (value <= 0 || value > 500000)
                    throw new InvalidCargoCapacityException("capacity must between 0 and 500,000 kg");
                _cargoCapacityValue = value;
            }
        }
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