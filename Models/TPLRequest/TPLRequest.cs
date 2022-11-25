using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using AldagiTPL.Models.Clients;
using AldagiTPL.Models.Vehicles;

namespace AldagiTPL.Models.TPLRequest
{
    public class TPLRequest
    {
        [Key]
        public int TPLRequestId { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Status { get; set; }

    }
}
