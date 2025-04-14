using System;

namespace VehicleManagementSystem.Vehicles
{
    public class Car : Vehicle{
        private string _modelValue;
        private string _horsePowerValue;
        
        public string Model {
            get
            {
                return _modelValue;
            }
            set
            {
                _modelValue = value;
            }
        }
        public string HorsePower{
            get
            {
                return _horsePowerValue;
            }
            set
            {
                _horsePowerValue = value;
            }
        }
        public Car(){
            VehicleType = "Car";
        }
        public override double CalculateTax(){
            return 0.1 * Price;
        }
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Horse Power: {HorsePower}");
        }
    }
}
