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
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }


        private void SaveCandidate(CandidateDto candidateDto)
        {
            var candidate = MapToEntity(candidateDto);
            _candidateRepository.Save(candidate);
        }
        private void UpdateCandidate(CandidateDto candidate, Candidate existingCandidate)
        {
            MapToEntity(candidate, existingCandidate);
            _candidateRepository.Update(existingCandidate);
        }
        public void UpsertCandidate(CandidateDto candidateDto)
        {
            var resulte = _candidateRepository.GetByEmail(candidateDto.Email);
            if (resulte == null)
            {
                SaveCandidate(candidateDto);
            }
            else
            {
                UpdateCandidate(candidateDto, resulte);
            }
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
        private void MapToEntity(CandidateDto candidateDto, Candidate candidate)
        {
            candidate.FirstName = candidateDto.FirstName;
            candidate.LastName = candidateDto.LastName;
            candidate.PhoneNumber = candidateDto.PhoneNumber;
            candidate.PreferredCallTime = candidateDto.PreferredCallTime;
            candidate.LinkedInProfileUrl = candidateDto.LinkedInProfileUrl;
            candidate.GitHubProfileUrl = candidateDto.GitHubProfileUrl;
            candidate.Comments = candidateDto.Comments;
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
