using Contoso.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Contoso.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyHistoryController : ControllerBase
    {
        private readonly ContosoDbContext _context;
        private readonly ILogger _logger;

        public PolicyHistoryController(ContosoDbContext context , ILogger<PolicyHistoryController> log)
        {
            _context = context;
            _logger = log;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var policyHistory = await _context.PolicyHistory
                   .AsNoTracking()
                   .ToListAsync();
            return await Task.FromResult(new JsonResult(policyHistory));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var policy = await _context.PolicyHistory.FindAsync(id);
            _logger.LogInformation("this is an info call");
            if (policy == null)
            {

                return new NotFoundObjectResult($"Dependent with Id {id} not found.");
            }

            return await Task.FromResult(new JsonResult(policy));
        }
    }
}