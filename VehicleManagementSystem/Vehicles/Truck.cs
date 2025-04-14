using System;

namespace VehicleManagementSystem.Vehicles
{
public class Truck : Vehicle{
    public double LoadCapacity { get; set; }
    public Truck(){
        VehicleType = "Truck";
    }
    public override double CalculateTax(){
        return 0.2 * Price;
    }   
    public override void DisplayInfo(){ 
        base.DisplayInfo();
        Console.WriteLine("Load Capacity: " + LoadCapacity);
    }
}
}
