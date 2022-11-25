namespace AldagiTPL.Models.Vehicles
{
    public class AddVehicle
    {
        public VehicleMarks.VehicleMarks Mark { get; set; }
        public VehicleModels.VehicleModels Model { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
