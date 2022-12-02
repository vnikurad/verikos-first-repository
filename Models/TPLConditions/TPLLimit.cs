using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace AldagiTPL.Models.TPLConditions
{
    public class TPLLimit
    {
        [Key]
        public int LimitId { get; set; }
        public decimal LimitAmount { get; set; }
        public decimal Premium { get; set; }
        public int ClientIntegration { get; set; }
    }
}
