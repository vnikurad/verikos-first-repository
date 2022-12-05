using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using AldagiTPL.Models.Marks;
using AldagiTPL.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AldagiTPL.Models.Vehicles
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }
        //public VehicleMarks VehicleMark { get; set; }
        public Guid VehicleMarkId { get; set; }
        //public VehicleModels VehicleModel { get; set; }
        public Guid VehicleModelId { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
    } 
}
