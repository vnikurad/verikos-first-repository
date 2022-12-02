using System.ComponentModel.DataAnnotations;

namespace AldagiTPL.Models.TPLConditions
{
    public class TPLStatuses
    {
        [Key]
        public int StatusId { get; set; }
        public string TPLStatusTitle { get; set; }
    }
}
