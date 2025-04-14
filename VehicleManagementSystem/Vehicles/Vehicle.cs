using System;
using VehicleManagementSystem.Exceptions;

namespace VehicleManagementSystem.Vehicles
{
    /// <summary>
    /// Lớp cơ sở trừu tượng cho tất cả các loại phương tiện
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        private string _name;
        private double _price;
        private double _speed;
        private string _vehicleType;
        
        /// <summary>
        /// Tên phương tiện
        /// </summary>
        public string Name{
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }
        
        /// <summary>
        /// Giá phương tiện
        /// </summary>
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
        
        /// <summary>
        /// Tốc độ phương tiện
        /// </summary>
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
        
        /// <summary>
        /// Loại phương tiện
        /// </summary>
        public string VehicleType{
            get{
                return _vehicleType;
            }
            set{
                _vehicleType = value;
            }
        }
        
        /// <summary>
        /// Hiển thị thông tin phương tiện
        /// </summary>
        public virtual void DisplayInfo(){
            Console.WriteLine($"\nName: {_name}");
            Console.WriteLine($"Price: {_price}");
            Console.WriteLine($"Speed: {_speed}");
            Console.WriteLine($"VehicleType: {_vehicleType}");
        }
        
        /// <summary>
        /// Tính toán thuế cho phương tiện
        /// </summary>
        /// <returns>Giá trị thuế</returns>
        public abstract double CalculateTax();
        
        /// <summary>
        /// Kiểm tra tính hợp lệ của phương tiện
        /// </summary>
        /// <returns>True nếu phương tiện hợp lệ, False nếu không</returns>
        public virtual bool IsValid()
        {
            return !string.IsNullOrEmpty(_name) && 
                   _price >= 0 && 
                   _speed > 0 && 
                   !string.IsNullOrEmpty(_vehicleType);
        }
    }
}