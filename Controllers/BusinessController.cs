using Microsoft.AspNetCore.Mvc;
using MyMvcApiProject.Data;

namespace MyMvcApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _businessRepository.GetBusinessByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}