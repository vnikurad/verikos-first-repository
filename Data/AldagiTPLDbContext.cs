using AldagiTPL.Models.Clients;
using AldagiTPL.Models.TPLRequest;
using AldagiTPL.Models.Marks;
using AldagiTPL.Models.Models;
using AldagiTPL.Models.Vehicles;
using AldagiTPL.Models.TPLConditions;
using Microsoft.EntityFrameworkCore;

namespace AldagiTPL.Data
{
    public class AldagiTPLDbContext : DbContext
    {
        public AldagiTPLDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TPLRequest> TPLRequests { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public  DbSet<VehicleMarks> VehicleMarks { get; set; } = null!;
        public  DbSet<VehicleModels> VehicleModels { get; set; } = null!;
        public DbSet<TPLLimit> TPLConditions { get; set; }
        public DbSet<TPLStatuses> TPLStatuses { get; set; }
    }
}
