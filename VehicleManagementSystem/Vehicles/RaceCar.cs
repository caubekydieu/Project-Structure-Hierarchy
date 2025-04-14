using System;

namespace VehicleManagementSystem.Vehicles
{
public class RaceCar : Car{
    public double TurboBoost { get; set; }
    public RaceCar(){
        VehicleType = "Race Car";
    }
    public override double CalculateTax(){
        return 0.1 * Price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Turbo Boost: " + TurboBoost);
    }
}
}