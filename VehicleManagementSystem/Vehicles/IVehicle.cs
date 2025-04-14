using System;

namespace VehicleManagementSystem.Vehicles
{
    /// <summary>
    /// Interface định nghĩa các phương thức cơ bản cho tất cả các loại phương tiện
    /// </summary>
    public interface IVehicle
    {
        string Name { get; set; }
        double Price { get; set; }
        double Speed { get; set; }
        string VehicleType { get; set; }
        
        /// <summary>
        /// Hiển thị thông tin của phương tiện
        /// </summary>
        void DisplayInfo();
        
        /// <summary>
        /// Tính toán thuế cho phương tiện
        /// </summary>
        /// <returns>Giá trị thuế</returns>
        double CalculateTax();
        
        /// <summary>
        /// Kiểm tra tính hợp lệ của phương tiện
        /// </summary>
        /// <returns>True nếu phương tiện hợp lệ, False nếu không</returns>
        bool IsValid();
    }
} 