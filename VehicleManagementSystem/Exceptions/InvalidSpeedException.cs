using System;
namespace VehicleManagementSystem.Exceptions{
    public class InvalidSpeedException : VehicleException{
        public InvalidSpeedException() : base("Speed is invalid"){}
        public InvalidSpeedException(string message) : base(message){}
        public InvalidSpeedException(string message, Exception inner) : base(message, inner){}
    }
}
