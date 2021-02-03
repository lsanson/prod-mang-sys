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
                var result = await Task.Run(() => _importationService.InsertImportations(file?.OpenReadStream()));
                if (result == null && !_importationService.IsValid())
                {
                    return BadRequest(_importationService.GetValidationErrors());
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetImportations()
        {
            try
            {
                var result = await Task.Run(() => _importationService.GetImportations());
                if (result == null)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImportation(Guid id)
        {
            try
            {
                var result = await Task.Run(() => _importationService.GetImportation(id));
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }
    }
}