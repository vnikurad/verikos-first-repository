using AldagiTPL.Data;
using AldagiTPL.Models.Clients;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public ClientController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(dbContext.Clients.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClient([FromRoute] Guid id)
        {
            try
            {
                var client = await dbContext.Clients.FindAsync(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
                       
        }


        [HttpPost]
        public IActionResult AddClient(AddClient request)
        {
            //if (!ModelState.IsValid)
            //{
            //    List<string> errors = new List<string>();
            //    foreach (var validation in ModelState.Values)
            //    {
            //        if (validation.ValidationState != Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            //        {
            //            foreach (var error in validation.Errors)
            //            {
            //                errors.Add(error.ErrorMessage);
            //            }
            //        }
            //    }
            //    return BadRequest(errors.ToArray());
            //}

            

            try
            {
                var client = new Client()
                {
                    ClientId = new Guid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PersonalNumber = request.PersonalNumber,
                    DateOfBirth = request.DateOfBirth,
                    Phone = request.Phone,
                    Email = request.Email
                };

                // Calculate the age.
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dateOfBirth = int.Parse(client.DateOfBirth.ToString("yyyyMMdd"));
                int age = (now - dateOfBirth) / 10000;

                if (age >= 18)
                {
                    dbContext.Clients.Add(client);
                    dbContext.SaveChanges();
                    return Ok(client);
                }
                else return BadRequest("Age is under 18");

            }
            catch (NullReferenceException nrex)
            {
                Log.Error(nrex.Message);
                return StatusCode(500);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500);
            }
            
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditClient([FromRoute] Guid id, EditClient request)
        {
                var updateRequest = await dbContext.Clients.FindAsync(id);

                if (updateRequest != null)
                {
                    updateRequest.FirstName = request.FirstName;
                    updateRequest.LastName = request.LastName;
                    updateRequest.PersonalNumber = request.PersonalNumber;
                    updateRequest.DateOfBirth = request.DateOfBirth;
                    updateRequest.Phone = request.Phone;
                    updateRequest.Email = request.Email;

                    await dbContext.SaveChangesAsync();

                    return Ok(updateRequest);

                }
                return NotFound();            
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            var client = await dbContext.Clients.FindAsync(id);

            if (client != null)
            {
                dbContext.Remove(client);
                await dbContext.SaveChangesAsync();
                return Ok(client);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
