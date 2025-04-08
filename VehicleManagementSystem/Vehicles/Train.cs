namespace VehicleManagementSystem.Vehicles;
{
public class Train : Vehicle{
    public double _units{ get; set;}
    public Train(){
        _vehicleType = "Train";
    };
    public override void CalculateTax(){
        return 0.2 * _price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Units: " + _units);
    }
}
}
