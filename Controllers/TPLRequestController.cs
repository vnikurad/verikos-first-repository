using AldagiTPL.Data;
using AldagiTPL.Models.Clients;
using AldagiTPL.Models.Responses.Tpl;
using AldagiTPL.Models.TPLConditions;
using AldagiTPL.Models.TPLRequest;
using AldagiTPL.Models.VehicleMarks;
using AldagiTPL.Models.VehicleModels;
using AldagiTPL.Models.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("{id:int}")]
        public IActionResult GetTPLRequest([FromRoute] int id)
        {
            var tplRequest = dbContext.TPLRequests.Include(x => x.Limit)
                .Include(x => x.Status)
                .FirstOrDefault(x => x.TPLRequestId == id);

            var responseModel = new GetTplRequestResponseModel()
            {
                Limit = tplRequest.Limit.LimitAmount,
                Premium = tplRequest.Limit.Premium,
                Status = tplRequest.Status.TPLStatusTitle
            };

            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult AddTPLRequest(CreateTPLRequest request)
        {            
            var newTplRequest = new TPLRequest()
            {
                StatusId = request.StatusId,
                LimitId = request.LimitId
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
                var newVehicleMark = new VehicleMarks()
                {
                    VehicleMarkId = Guid.NewGuid(),
                    VehicleMarkName = request.Vehicle.VehicleMark.VehicleMarkName
                };

                dbContext.Add(newVehicleMark);
                dbContext.SaveChanges();

                var newVehicleModel = new VehicleModels()
                {
                    VehicleMarkId = newVehicleMark.VehicleMarkId,
                    VehicleModelId = Guid.NewGuid(),
                    VehicleModelName = request.Vehicle.VehicleModel.VehicleModelName
                };

                dbContext.VehicleModels.Add(newVehicleModel);
                dbContext.SaveChanges();

                var newVehicle = new Vehicle()
                {
                    VehicleId = new Guid(),
                    VehicleMark = newVehicleMark,
                    VehicleModel = newVehicleModel,
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
