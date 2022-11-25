using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AldagiTPL.Models.VehicleMarks
{
    public class VehicleMarks
    {
        [Key]
        public Guid VehicleMarkId { get; set; }
        public string VehicleMarkName { get; set; }
    }
}
