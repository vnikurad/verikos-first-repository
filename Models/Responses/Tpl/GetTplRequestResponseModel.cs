namespace AldagiTPL.Models.Responses.Tpl
{
    public class GetTplRequestResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal Limit { get; set; }
        public decimal Premium { get; set; }
        public string Status { get; set; }
    }
}
