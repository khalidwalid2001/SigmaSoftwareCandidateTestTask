using Api.Models;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public IActionResult SaveCandidate([FromBody] CandidateDto candidateRequest)
        {
             

            _candidateService.UpsertCandidate(candidateRequest);
            return Ok();
        }

        
    }
}
