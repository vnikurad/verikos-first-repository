using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AldagiTPL.Models.Clients
{
    public class AddClient
    {
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string LastName { get; set; }

        [RegularExpression("[0-9]{11}")]
        [Required]
        public string PersonalNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression("((5)[0-9]{8})")]
        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
