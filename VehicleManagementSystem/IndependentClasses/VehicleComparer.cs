using System;
using VehicleManagementSystem.Vehicles;

namespace VehicleManagementSystem.IndependentClasses;
{
    public class VehicleComparer{
        public void SortByPrice(Vehicle[] vehicles){
            for(int i = 0; i < vehicles.Length - 1; i++){
                for(int j = 0; j < vehicles.Length - i -1, j++){
                    if(vehicles[j].Price < vehicles[j + 1].Price){
                        var temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
        }   
        public void SortBySpeed(Vehicle[] vehicles){
            for(int i = 0; i < vehicles.Length - 1; i++){
                for(int j = 0; j < vehicles.Length - i -1, j++){
                    if(vehicles[j].Speed < vehicles[j + 1].Speed){
                        var temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
        }
        public void SortByType(Vehicle[] vehicles){
            for(int i = 0; i < vehicles.Length - 1; i++){
                for(int j = 0; j < vehicles.Length - i -1, j++){
                    if(vehicles[j].Speed < vehicles[j + 1].Speed){
                        var temp = vehicles[j];
                        vehicles[j] = vehicles[j + 1];
                        vehicles[j + 1] = temp;
                    }
                }
            }
        }
    }
}
