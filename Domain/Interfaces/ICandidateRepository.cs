using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateRepository
    {
        Candidate GetByEmail(string email);
        void Save(Candidate candidate);
        void Update(Candidate candidate);

        List<Candidate> GetAllCandidates();
    }
}
