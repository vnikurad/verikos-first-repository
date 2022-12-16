using AldagiTPL.Data;
using AldagiTPL.Models.Clients;
using AldagiTPL.Models.Responses.Tpl;
using AldagiTPL.Models.TPLConditions;
using AldagiTPL.Models.TPLRequest;
using AldagiTPL.Models.Marks;
using AldagiTPL.Models.Models;
using AldagiTPL.Models.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using AldagiTPL.Models;

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
            try
            {
                var tplRequest = dbContext.TPLRequests.Include(x => x.Limit)
                .Include(x => x.Status)
                .Include(x => x.Client)
                .Include(x => x.Vehicle)
                .FirstOrDefault(x => x.TPLRequestId == id);

                var responseModel = new GetTplRequestResponseModel()
                {
                    FirstName = tplRequest.Client.FirstName,
                    LastName = tplRequest.Client.LastName,
                    PersonalNumber = tplRequest.Client.PersonalNumber,
                    DateOfBirth = tplRequest.Client.DateOfBirth,
                    Phone = tplRequest.Client.Phone,
                    Email = tplRequest.Client.Email,
                    VehicleYear = tplRequest.Vehicle.VehicleYear,
                    RegistrationNumber = tplRequest.Vehicle.RegistrationNumber,
                    Limit = tplRequest.Limit.LimitAmount,
                    Premium = tplRequest.Limit.Premium,
                    Status = tplRequest.Status.TPLStatusTitle
                };

                return Ok(responseModel);
            }
            catch (NullReferenceException nrex)
            {
                Log.Error(nrex.Message);
                return BadRequest(nrex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddTPLRequest(CreateTPLRequest request)
        {
            try
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
                    var newVehicle = new Vehicle()
                    {
                        VehicleId = new Guid(),
                        VehicleMarkId = request.Vehicle.VehicleMarkId,
                        VehicleModelId = request.Vehicle.VehicleModelId,
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
            catch (NullReferenceException nrex)
            {
                Log.Error(nrex.Message);
                return BadRequest(nrex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditTPLRequest([FromRoute] int id, EditTPLRequest request)
        {
            var updateTPLRequest = dbContext.TPLRequests.Find(id);

            if (updateTPLRequest != null)
            {
                updateTPLRequest.StatusId = request.StatusId;

                dbContext.SaveChanges();
                return Ok(updateTPLRequest);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTPLRequest([FromRoute] int id)
        {
            var tplRequest = dbContext.TPLRequests.Find(id);

            if (tplRequest != null && tplRequest.StatusId != 2)
            {
                dbContext.Remove(tplRequest);
                dbContext.SaveChanges();
                return Ok(tplRequest);
            }
            else if (tplRequest.StatusId == 2)
            {
                return BadRequest("გადახდილი სტატუსის მქონე ჩანაწერის წაშლა არ შეიძლება");
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPost("{TPLRequestId:int}/UploadFiles")]
        //public async Task<IActionResult> UploadFiles(int TPLRequestId)
        //{
        //    var photos = await dbContext.TPLRequests.Where(x => x.TPLRequestId == TPLRequestId).ToListAsync();

        //    foreach (var photo in photos)
        //    {
        //        var photoUploadRequest = new TPLPhotoUploadRequest()
        //        {
        //            Name = "Picture_" + photo.TPLRequestId,
        //            Extension = "png"
        //        };


        //        var json = JsonConvert.SerializeObject(photoUploadRequest);
        //        var data = new StringContent(json, Encoding.UTF8, "application/json");

        //        dbContext.TPLRequests.Update(photo);
        //        dbContext.SaveChanges();

        //    }

        //    return NoContent();
        //}


    }
}