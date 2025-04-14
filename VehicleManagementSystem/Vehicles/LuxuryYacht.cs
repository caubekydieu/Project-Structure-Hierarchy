using System;

namespace VehicleManagementSystem.Vehicles
{
public class LuxuryYacht : Boat{
    public double Helipad { get; set; }
    public LuxuryYacht(){
        VehicleType = "Luxury Yacht";
    }
    public override double CalculateTax(){
        return 0.05 * Price;
    }
    public override void DisplayInfo(){ 
        base.DisplayInfo();
        Console.WriteLine("Helipad: " + Helipad);
    }
}
}
