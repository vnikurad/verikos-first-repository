using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using AldagiTPL.Models.Clients;
using AldagiTPL.Models.Vehicles;
using AldagiTPL.Models.TPLConditions;

namespace AldagiTPL.Models.TPLRequest
{
    public class TPLRequest
    {
        [Key]
        public int TPLRequestId { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
        public TPLStatuses Status { get; set; }
        public int StatusId { get; set; }
        public TPLLimit Limit { get; set; }
        public int LimitId { get; set; }

    }
}
