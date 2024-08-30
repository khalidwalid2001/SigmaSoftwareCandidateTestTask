using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CandidateService: ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

  

        public void SaveCandidate(CandidateDto candidateDto)
        {
            var candidate = MapToEntity(candidateDto);
            _candidateRepository.Save(candidate);
        }

        private CandidateDto MapToDto(Candidate candidate)
        {
            return new CandidateDto
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Email = candidate.Email,
                PhoneNumber = candidate.PhoneNumber,
                PreferredCallTime = candidate.PreferredCallTime,
                LinkedInProfileUrl = candidate.LinkedInProfileUrl,
                GitHubProfileUrl = candidate.GitHubProfileUrl,
                Comments = candidate.Comments
            };
        }

        private Candidate MapToEntity(CandidateDto candidateDto)
        {
            return new Candidate
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                Email = candidateDto.Email,
                PhoneNumber = candidateDto.PhoneNumber,
                PreferredCallTime = candidateDto.PreferredCallTime,
                LinkedInProfileUrl = candidateDto.LinkedInProfileUrl,
                GitHubProfileUrl = candidateDto.GitHubProfileUrl,
                Comments = candidateDto.Comments
            };
        }
    }
}
