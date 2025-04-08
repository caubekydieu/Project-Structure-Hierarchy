public class Car : Vehicle{
    public string _model {
        get{
            return _model;
        }
        set{
            _model = value;
        }
    };
    public string _horsePower{
        get{
            return _horsePower;
        }
        set{
            _horsePower = value;
        }
    };
    public Car(){
        _vehicleType = "Car";
    };
    public override void CalculateTax(){
        return 0.1 * _price;
    }
    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine("Model: " + _model);
        Console.WriteLine("Horse Power: " + _horsePower);
    }
}

