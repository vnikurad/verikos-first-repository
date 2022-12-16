using AldagiTPL.Data;
using AldagiTPL.Models.TPLConditions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPLStatusController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public TPLStatusController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTPLStatuses()
        {
            return Ok(dbContext.TPLStatuses.ToList());
        }

        [HttpPost]
        
        public IActionResult AddTPLStatus(AddTPLStatus request)
        {
            var newStatus = new TPLStatuses()
            {
                TPLStatusTitle = request.TPLStatusTitle
            };

            dbContext.TPLStatuses.Add(newStatus);
            dbContext.SaveChanges();
            return Ok(newStatus);
        }
    }
}
