using Microsoft.AspNetCore.Mvc;
using BioSharpApi.Services;
using Microsoft.EntityFrameworkCore;

namespace BioSharpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DnaController : ControllerBase
    {
        private readonly IDnaService _dnaService;

        // Constructor Injection
        public DnaController(IDnaService dnaService)
        {
            _dnaService = dnaService;
        }

        // POST api/dna/validate
        [HttpPost("validate")]
        public IActionResult Validate([FromBody] DnaRequest request)
        {
            var isValid = _dnaService.ValidateSequence(request.Sequence);
            
            if (isValid)
                return Ok(new { valid = true, message = "Sequence is valid." });
            
            return BadRequest(new { valid = false, message = "Sequence contains invalid characters." });
        }

        // POST api/dna/analyze
        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze([FromBody] DnaRequest request)
        {
            if (!_dnaService.ValidateSequence(request.Sequence))
            {
                return BadRequest("Invalid DNA sequence provided.");
            }

            var result = await _dnaService.SaveAnalysisAsync(request.Sequence);

            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory([FromServices] BioSharpApi.Data.BioContext context)
        {
            var history = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(context.AnalysisHistory);
            return Ok(history);
        }
    }

    // Input Model (Data Transfer Object)
    public record DnaRequest(string Sequence);
}