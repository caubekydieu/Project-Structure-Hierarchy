using System;

namespace VehicleManagementSystem.Exceptions{
    public class InvalidCargoCapacityException : VehicleException{
        public InvalidCargoCapacityException() : base("Cargo capacity is invalid or unrealistic"){}
        public InvalidCargoCapacityException(string message) : base(message){}
        public InvalidCargoCapacityException(string message, Exception inner) : base(message, inner){}
    }
}
