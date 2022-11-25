using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using AldagiTPL.Models.VehicleMarks;
using AldagiTPL.Models.VehicleModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace AldagiTPL.Models.Vehicles
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }
        public VehicleMarks.VehicleMarks VehicleMark { get; set; }
        public VehicleModels.VehicleModels VehicleModel { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
    } 
}
