namespace VehicleManagementSystem.Vehicles;
{
public class RaceCar : car{
    public TurboBoost(){get; set;}
    public RaceCar(){
        _vehicleType = "Race Car";
    }
    public override void CalculateTax(){
        return 0.1 * _price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Turbo Boost: " + _turboBoost);
    }
}
}