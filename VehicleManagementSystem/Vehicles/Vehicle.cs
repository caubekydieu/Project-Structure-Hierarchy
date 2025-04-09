using System;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles
{
    public abstract class Vehicle
    {
        private string _name;
        private double _price;
        private double _speed;
        private string _vehicleType;
        public string Name{
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }
        public double Price{
            get{
                return _price;
            }
            set{
                if (value < 0)
                    throw new InvalidPriceException("Price cannot be negative");
                _price = value;
            }
        }
        public double Speed{
            get{
                return _speed;
            }
            set{
                if (value <= 0)
                    throw new InvalidSpeedException("Speed must be greater than zero");
                _speed = value;
            }
        }
        public string VehicleType{
            get{
                return _vehicleType;
            }
            set{
                _vehicleType = value;
            }
        }
        virtual public void DisplayInfo(){
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Price: " + _price);
            Console.WriteLine("Speed: " + _speed);
            Console.WriteLine("Vehicle Type: " + _vehicleType);
        }
        abstract public double CalculateTax();
        //empty 
    }
}