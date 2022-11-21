using AldagiTPL.Data;
using AldagiTPL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // ვცდილობ grdb-დან ავიღო მარკები
        /*public IActionResult Index()
        {
            var marks = dbContext.Vehicles.Select(x => x.Mark).Distinct().ToList();
            return Ok(marks);
        }*/

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
            var vehicle = new Vehicle()
            {
                VehicleId = new Guid(),
                Mark = request.Mark,
                Model = request.Model,
                VehicleYear = request.VehicleYear,
                RegistrationNumber = request.RegistrationNumber
            };

            dbContext.Vehicles.Add(vehicle);
            dbContext.SaveChanges();
            return Ok(vehicle);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditVehicle([FromRoute] Guid id, EditVehicle request)
        {
            var updateRequest = await dbContext.Vehicles.FindAsync(id);

            if (updateRequest != null)
            {
                updateRequest.Mark = request.Mark;
                updateRequest.Model = request.Model;
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
