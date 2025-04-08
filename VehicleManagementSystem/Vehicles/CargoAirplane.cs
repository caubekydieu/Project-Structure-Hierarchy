namespace VehicleManagementSystem.Vehicles;
{
public class CargoAirplane : Airplane{
    public double _cargoCapacity{ get; set}
    public CargoAirplane(){

        _vehicleType = "Cargo Airplane";
    };
    public override void CalculateTax(){
        return 0.15 * _price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Cargo Capacity: " + _cargoCapacity);
    }
}
}