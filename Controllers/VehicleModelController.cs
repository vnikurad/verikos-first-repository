using AldagiTPL.Data;
using AldagiTPL.Models.VehicleMarks;
using AldagiTPL.Models.VehicleModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public VehicleModelController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetVehicleModels()
        {
            return Ok(dbContext.VehicleModels.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetVehicleModel([FromRoute] Guid id)
        {
            var vehicleModel = await dbContext.VehicleModels.FindAsync(id);
            return Ok(vehicleModel);
        }


        [HttpPost]
        public IActionResult AddVehicleModel(AddVehicleModel request)
        {
            var vehicleModel = new VehicleModels()
            {
                VehicleModelName = request.VehicleModelName,
                VehicleMarkId = request.VehicleMarkId
            };

            dbContext.VehicleModels.Add(vehicleModel);
            dbContext.SaveChanges();
            return Ok(vehicleModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteVehicleModel([FromRoute] Guid id)
        {
            var vehicleModel = await dbContext.VehicleModels.FindAsync(id);

            if (vehicleModel != null)
            {
                dbContext.Remove(vehicleModel);
                await dbContext.SaveChangesAsync();
                return Ok(vehicleModel);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
