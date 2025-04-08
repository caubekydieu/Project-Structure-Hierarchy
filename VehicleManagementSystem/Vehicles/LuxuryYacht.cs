namespace VehicleManagementSystem.Vehicles;
{
public class LuxuryYacht : Boat{
    public double _helipad{ get; set;}
    public LuxuryYacht(){
        _vehicleType = "Luxury Yacht";
    };
    public override void CalculateTax(){
        return 0.05 * _price;
    }
    public override void DisplayInfo(){ 
        base.DisplayInfo();
        Console.WriteLine("Helipad: " + _helipad);
    }
}
}
