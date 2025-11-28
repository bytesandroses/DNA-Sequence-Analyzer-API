using Microsoft.AspNetCore.Mvc;
using BioSharpApi.Services;

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
        public IActionResult Analyze([FromBody] DnaRequest request)
        {
            // 1. Validation First
            if (!_dnaService.ValidateSequence(request.Sequence))
            {
                return BadRequest("Invalid DNA sequence provided.");
            }

            // 2. Perform Analysis
            var result = new
            {
                Original = request.Sequence,
                Transcribed = _dnaService.Transcribe(request.Sequence),
                ReverseComplement = _dnaService.GetReverseComplement(request.Sequence),
                GcContent = _dnaService.GetGcContent(request.Sequence)
            };

            return Ok(result);
        }
    }

    // Input Model (Data Transfer Object)
    public record DnaRequest(string Sequence);
}