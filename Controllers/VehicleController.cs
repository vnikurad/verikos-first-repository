using AldagiTPL.Data;
using AldagiTPL.Models.Clients;
using AldagiTPL.Models.Marks;
using AldagiTPL.Models.Models;
using AldagiTPL.Models.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public VehicleController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetVehicles()   
        {
            return Ok(dbContext.Vehicles.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetVehicle([FromRoute] Guid id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);
            return Ok(vehicle);
        }


        [HttpPost]
        public IActionResult AddVehicle(AddVehicle request)
        {
            var newVehicle = new Vehicle()
            {
                VehicleId = new Guid(),
                VehicleYear = request.VehicleYear,
                RegistrationNumber = request.RegistrationNumber,
                VehicleMarkId = request.VehicleMarkId,
                VehicleModelId = request.VehicleModelId
            };

            //if (request.Mark != null)
            //{
            //    var newVehicleMark = new VehicleMarks()
            //    {
            //        VehicleMarkId = new Guid(),
            //        VehicleMarkName = request.Mark.VehicleMarkName
            //    };

            //    dbContext.Add(newVehicleMark);
            //    dbContext.SaveChanges();
            //    newVehicle.VehicleMark = newVehicleMark;
            //}

            //if(request.Model != null)
            //{
            //    var newVehicleModel = new VehicleModels()
            //    {
            //        VehicleModelId = new Guid(),
            //        VehicleModelName = request.Model.VehicleModelName,
            //        VehicleMarkId = request.Model.VehicleMarkId
            //    };

            //    dbContext.Add(newVehicleModel);
            //    dbContext.SaveChanges();
            //    newVehicle.VehicleModel = newVehicleModel;
                    
            //}
            

            dbContext.Vehicles.Add(newVehicle);
            dbContext.SaveChanges();
            return Ok(newVehicle);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditVehicle([FromRoute] Guid id, EditVehicle request)
        {
            var updateRequest = await dbContext.Vehicles.FindAsync(id);

            if (updateRequest != null)
            {
                updateRequest.VehicleMarkId = request.VehicleMarkId;
                updateRequest.VehicleModelId = request.VehicleModelId;
                updateRequest.VehicleYear = request.VehicleYear;
                updateRequest.RegistrationNumber = request.RegistrationNumber;

                await dbContext.SaveChangesAsync();

                return Ok(updateRequest);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] Guid id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);

            if (vehicle != null)
            {
                dbContext.Remove(vehicle);
                await dbContext.SaveChangesAsync();
                return Ok(vehicle);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
