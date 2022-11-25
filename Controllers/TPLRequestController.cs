using AldagiTPL.Data;
using AldagiTPL.Models.Clients;
using AldagiTPL.Models.TPLRequest;
using AldagiTPL.Models.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPLRequestController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public TPLRequestController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTPLRequests()
        {
            return Ok(dbContext.TPLRequests.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetTPLRequest([FromRoute] Guid id)
        {
            var tplRequest = dbContext.TPLRequests.Find(id);
            return Ok(tplRequest);
        }

        [HttpPost]
        public IActionResult AddTPLRequest(CreateTPLRequest request)
        {
            
                var newTplRequest = new TPLRequest()
                {
                    Status = request.Status
                };

                if (request.Client != null)
                {
                    var newClient = new Client()
                    {
                        ClientId = new Guid(),
                        FirstName = request.Client.FirstName,
                        LastName = request.Client.LastName,
                        PersonalNumber = request.Client.PersonalNumber,
                        DateOfBirth = request.Client.DateOfBirth,
                        Phone = request.Client.Phone,
                        Email = request.Client.Email
                    };

                    dbContext.Add(newClient);
                    dbContext.SaveChanges();
                    newTplRequest.Client = newClient;
                }

                if (request.Vehicle != null)
                {
                    var newVehicle = new Vehicle()
                    {
                        VehicleId = new Guid(),
                        VehicleMark = request.Vehicle.VehicleMark,
                        VehicleModel = request.Vehicle.VehicleModel,
                        VehicleYear = request.Vehicle.VehicleYear,
                        RegistrationNumber = request.Vehicle.RegistrationNumber
                    };

                    dbContext.Add(newVehicle);
                    dbContext.SaveChanges();
                    newTplRequest.Vehicle = newVehicle;
                }

                dbContext.TPLRequests.Add(newTplRequest);
                dbContext.SaveChanges();


                return Ok(newTplRequest);
            
            
        }

    }
}
