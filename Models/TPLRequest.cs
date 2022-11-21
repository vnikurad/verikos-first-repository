using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AldagiTPL.Models
{
    public class TPLRequest
    {
        [Key]
        public int TPLRequestId { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
        //public TPLConditions TPLConditions { get; set; }

        //ფაილები: განაცხადზე უნდა აიტვირთოს პირადობის სურათი. არაუმეტეს 2MB ზომის


    }
}
