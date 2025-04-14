using System;

namespace VehicleManagementSystem.Vehicles
{
public class Boat : Vehicle{
    public double SeatingCapacity { get; set; }
    public Boat(){
        VehicleType = "Boat";
    }
    public override double CalculateTax(){
        return 0.05 * Price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Seating Capacity: " + SeatingCapacity);
    }
}
}