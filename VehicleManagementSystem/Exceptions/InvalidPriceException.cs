using System;
namespace VehicleManagementSystem.Exceptions{
    public class InvalidPriceException : VehicleException{
        public InvalidPriceException() : base("Price is invalid"){}
        public InvalidPriceException(string message) : base(message){}
        public InvalidPriceException(string message, Exception inner) : base(message, inner){}
    }
}
