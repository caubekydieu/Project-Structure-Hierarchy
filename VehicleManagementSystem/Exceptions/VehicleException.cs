using system;
namespace VehicleManagementSystem.Exceptions{
    public class VehicleException : Exceptions{
        public VehicleException(){}        
        public VehicleException(string message) : base(message) { }
        public VehicleException(string message, Exception inner) : base(message, inner) { }
    }
}