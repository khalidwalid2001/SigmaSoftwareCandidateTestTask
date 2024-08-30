using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CsvCandidateRepository : ICandidateRepository
    {
        private readonly string _filePath;
        private List<Candidate> _cachedCandidates;
        private DateTime _cacheExpiration;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

        public CsvCandidateRepository(string filePath)
        {
            _filePath = filePath;
            _cachedCandidates = null;
            _cacheExpiration = DateTime.MinValue;
        }

        private List<Candidate> GetCachedCandidates()
        {
            if (_cachedCandidates == null || DateTime.Now > _cacheExpiration)
            {
                _cachedCandidates = CsvFileHelper.ReadCsvFile(_filePath);
                _cacheExpiration = DateTime.Now.Add(_cacheDuration);
            }
            return _cachedCandidates;
        }

        public Candidate GetByEmail(string email)
        {
            var candidates = GetCachedCandidates();
            return candidates.FirstOrDefault(c => c.Email == email);
        }

        public void Save(Candidate candidate)
        {
            var candidates = GetCachedCandidates();

            // Check if the candidate already exists
            var existingCandidate = candidates.FirstOrDefault(c => c.Email == candidate.Email);
            if (existingCandidate != null)
            {
                throw new InvalidOperationException("A candidate with the same email already exists.");
            }

            candidates.Add(candidate);
            CsvFileHelper.WriteCsvFile(_filePath, candidates);
             _cachedCandidates.Add(candidate);
        }

        public List<Candidate> GetAllCandidates()
        {
            return GetCachedCandidates();
        }
        //   please make sure read commint 
        //  The current implementation has limitations because it doesn't allow for updating records based on a unique key or executing changes through a query.
        //  This is due to the fact that each line in the CSV file doesn't have a reference value or unique identifier, making it difficult to reliably update specific records.     

        public void Update(Candidate candidate)
        {
            var candidates = GetCachedCandidates();

            var existingCandidate = candidates.FirstOrDefault(c => c.Email == candidate.Email);
            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.PreferredCallTime = candidate.PreferredCallTime;
                existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
                existingCandidate.Comments = candidate.Comments;

                CsvFileHelper.WriteCsvFile(_filePath, candidates);

 
            }
            else
            {
                throw new KeyNotFoundException("No candidate found with the provided email.");
            }
        }
    }
}
