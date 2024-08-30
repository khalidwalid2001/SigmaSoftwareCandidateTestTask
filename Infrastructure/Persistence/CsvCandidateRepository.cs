using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Utilities;
using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CsvCandidateRepository : ICandidateRepository
    {

        private readonly string _filePath;

        public CsvCandidateRepository(string filePath)
        {
            _filePath = filePath;
        }

        public Candidate GetByEmail(string email)
        {
            var candidates = CsvFileHelper.ReadCsvFile(_filePath);
            return candidates.FirstOrDefault(c => c.Email == email);
        }

        public void Save(Candidate candidate)
        {
            var candidates = CsvFileHelper.ReadCsvFile(_filePath);
            candidates.Add(candidate);
            CsvFileHelper.WriteCsvFile(_filePath, candidates);
        }

        public List<Candidate> GetAllCandidates()
        {
            return CsvFileHelper.ReadCsvFile(_filePath);
        }
 


        //   please make sure read commint 
        //  The current implementation has limitations because it doesn't allow for updating records based on a unique key or executing changes through a query.
        //  This is due to the fact that each line in the CSV file doesn't have a reference value or unique identifier, making it difficult to reliably update specific records.     
        public void Update(Candidate candidate)
        {
            var candidates = CsvFileHelper.ReadCsvFile(_filePath);

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
