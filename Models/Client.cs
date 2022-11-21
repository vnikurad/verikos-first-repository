using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AldagiTPL.Models
{
    public class Client
    {
        /*პირადი ინფორმაცია: სახელი, გვარი, პირადი ნომერი, დაბ. თარიღი, მობილური და ელ-ფოსტა. 
       * ელ-ფოსტის გარდა ყველაფერი სავალდებულოა, ასევე უნდა მოხდეს პირადი ნომრის (11 ნიშნა), 
       * მობილურის (5********) და ელ-ფოსტის ვალიდაცია. მინიმალური დასაშვები ასაკი 18 წელი.*/
        [Key]
        public Guid ClientId { get; set; }        
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
