using AldagiTPL.Data;
using AldagiTPL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPLController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public TPLController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTPLRequest()
        {
            return Ok(dbContext.TPLRequests.ToList());
        }        
 
    }
}
