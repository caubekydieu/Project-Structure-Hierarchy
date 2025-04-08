namespace VehicleManagementSystem.Vehicles;
{
public class Boat : Vehicle{
    public double _seatingCapacity{ get; set;}
    public Boat(){
        _vehicleType = "Boat";
    };
    public override void CalculateTax(){
        return 0.05 * _price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Seating Capacity: " + _seatingCapacity);
    }
}
}