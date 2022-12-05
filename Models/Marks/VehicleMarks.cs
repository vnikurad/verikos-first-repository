using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AldagiTPL.Models.Marks
{
    public class VehicleMarks
    {
        [Key]
        public Guid VehicleMarkId { get; set; }
        public string VehicleMarkName { get; set; }
    }
}
