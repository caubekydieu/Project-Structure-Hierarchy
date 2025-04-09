using System;

namespace VehicleManagementSystem.Vehicles
{
    public class Airplane : Vehicle
    {
        public double Altitude { get; set; }
        
        public Airplane()
        {
            VehicleType = "Airplane";
        }
        
        public override double CalculateTax()
        {
            return 0.15 * Price;
        }
        
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.WriteLine("Altitude: " + Altitude);
        }
    }
}
