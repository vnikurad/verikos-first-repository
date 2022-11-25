using AldagiTPL.Models.Clients;
using AldagiTPL.Models.Vehicles;

namespace AldagiTPL.Models.TPLRequest
{
    public class EditTPLRequest
    {
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Status { get; set; }
    }
}
