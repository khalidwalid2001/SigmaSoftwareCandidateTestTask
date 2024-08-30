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
        public IActionResult SaveCandidate([FromBody] CandidateRequestModel candidateRequest)
        {
            var candidateDto = new CandidateDto
            {
                FirstName = candidateRequest.FirstName,
                LastName = candidateRequest.LastName,
                Email = candidateRequest.Email,
                PhoneNumber = candidateRequest.PhoneNumber,
                PreferredCallTime = candidateRequest.PreferredCallTime,
                LinkedInProfileUrl = candidateRequest.LinkedInProfileUrl,
                GitHubProfileUrl = candidateRequest.GitHubProfileUrl,
                Comments = candidateRequest.Comments
            };

            _candidateService.SaveCandidate(candidateDto);
            return Ok();
        }

        
    }
}
