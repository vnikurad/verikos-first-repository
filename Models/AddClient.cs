using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AldagiTPL.Models
{
    public class AddClient
    {
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Personal Number")]
        [Required]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters")]
        public string PersonalNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        [DisplayName("Date Of Birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(9)")]
        [RegularExpression("([0-9]+)")]
        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
