namespace VehicleManagementSystem.Vehicles;
{
public class Airplane : Vehicle{
    public double _altitude{ get; set;}
    public Airplane(){
        _vehicleType = "Airplane";
    };
    public override void CalculateTax(){
        return 0.15 * _price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Altitude: " + _altitude);
    }
    
}
}
