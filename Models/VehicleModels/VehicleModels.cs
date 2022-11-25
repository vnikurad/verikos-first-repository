﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AldagiTPL.Models.VehicleModels
{
    public class VehicleModels
    {
        [Key]
        public Guid VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public Guid VehicleMarkId { get; set; }
    }
}
