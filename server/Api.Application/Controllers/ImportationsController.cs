using System;
using System.Threading.Tasks;
using Api.Domain.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportationsController : ControllerBase
    {
        private IImportationService _importationService;

        public ImportationsController(IImportationService importationService)
        {
            _importationService = importationService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(IFormFile file)
        {
            try
            {
                var result = _importationService.InsertImportations(file.OpenReadStream());
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }
    }
}