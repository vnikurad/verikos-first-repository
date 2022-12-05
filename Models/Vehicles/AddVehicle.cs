namespace AldagiTPL.Models.Vehicles
{
    public class AddVehicle
    {
        public Guid VehicleMarkId { get; set; }
        public Guid VehicleModelId { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
