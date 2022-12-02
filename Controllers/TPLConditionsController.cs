using AldagiTPL.Data;
using AldagiTPL.Models.TPLConditions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AldagiTPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPLConditionsController : ControllerBase
    {
        private readonly AldagiTPLDbContext dbContext;

        public TPLConditionsController(AldagiTPLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTPLConditions()
        {
            return Ok(dbContext.TPLConditions.ToList());
        }

        [HttpPost]
        public IActionResult AddTPLCondition(AddTPLLimit request)
        {
            var newTPLCondition = new TPLLimit()
            {
                LimitAmount = request.LimitAmount,
                Premium = request.Premium,
                ClientIntegration = request.ClientIntegration
            };

            dbContext.TPLConditions.Add(newTPLCondition);
            dbContext.SaveChanges();
            return Ok(newTPLCondition);
        }
    }
}
