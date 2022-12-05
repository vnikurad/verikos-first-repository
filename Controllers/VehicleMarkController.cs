using AldagiTPL.Data;
using AldagiTPL.Models.Marks;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMarkController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public VehicleMarkController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetVehicleMarks()
        {
            return Ok(dbContext.VehicleMarks.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetVehicleMark([FromRoute] Guid id)
        {
            var vehicleMark = await dbContext.VehicleMarks.FindAsync(id);
            return Ok(vehicleMark);
        }


        [HttpPost]
        public IActionResult AddVehicleMark(AddVehicleMark request)
        {
            var vehicleMark = new VehicleMarks()
            {
                VehicleMarkName = request.VehicleMarkName                
            };

            dbContext.VehicleMarks.Add(vehicleMark);
            dbContext.SaveChanges();
            return Ok(vehicleMark);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteVehicleMark([FromRoute] Guid id)
        {
            var vehicleMark = await dbContext.VehicleMarks.FindAsync(id);

            if (vehicleMark != null)
            {
                dbContext.Remove(vehicleMark);
                await dbContext.SaveChangesAsync();
                return Ok(vehicleMark);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
