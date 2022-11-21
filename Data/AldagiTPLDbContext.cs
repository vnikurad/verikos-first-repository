using AldagiTPL.Models;
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
        public  DbSet<AutoMark> AutoMarks { get; set; } = null!;
        public  DbSet<AutoModel> AutoModels { get; set; } = null!;
    }
}
