namespace AldagiTPL.Models.Vehicles
{
    public class EditVehicle
    {
        public VehicleMarks.VehicleMarks Mark { get; set; }
        public VehicleModels.VehicleModels Model { get; set; }
        public int VehicleYear { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
