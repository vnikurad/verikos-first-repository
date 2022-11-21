using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AldagiTPL.Models
{
    public class Vehicle
    {
        /*მანქანის მახასიათებლები: მწარმოებელი, მოდელი, გამოშვების წელი, რეგისტრაციის ნომერი. 
               მწარმოებელი და მოდელი ერთმანეთზეა დამოკიდებული უნდა აირჩეს წინასწარ გამზადებული სიიდან, 
               რომელსაც ასევე API-ის აბრუნებს. */
        [Key]
        public Guid VehicleId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
