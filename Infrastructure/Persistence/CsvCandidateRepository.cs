using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CsvCandidateRepository: ICandidateRepository
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

            var existingCandidate = candidates.FirstOrDefault(c => c.Email == candidate.Email);
            if (existingCandidate != null)
            {
                candidates.Remove(existingCandidate);
            }

            candidates.Add(candidate);
            CsvFileHelper.WriteCsvFile(_filePath, candidates);
        }

        public List<Candidate> GetAllCandidates()
        {
            return CsvFileHelper.ReadCsvFile(_filePath);
        }
    }
}
