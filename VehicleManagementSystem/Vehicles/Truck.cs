namespace VehicleManagementSystem.Vehicles;
{
public class Truck : Vehicle{
    public double _loadCapacity{ get; set;}
    public Truck(){
        _vehicleType = "Truck";
    };
    public override void CalculateTax(){
        return 0.2 * _price;
    }   
    public override void DisplayInfo(){ 
        base.DisplayInfo();
        Console.WriteLine("Load Capacity: " + _loadCapacity);
    }
}
}
