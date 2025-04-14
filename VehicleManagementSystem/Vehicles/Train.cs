using System;

namespace VehicleManagementSystem.Vehicles
{
public class Train : Vehicle{
    public double Units { get; set; }
    public Train(){
        VehicleType = "Train";
    }
    public override double CalculateTax(){
        return 0.2 * Price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Units: " + Units);
    }
}
}
