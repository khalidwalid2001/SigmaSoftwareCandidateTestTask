using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities
{
    public class CsvFileHelper
    {
        public static List<Candidate> ReadCsvFile(string filePath)
        {
            var candidates = new List<Candidate>();

            if (!File.Exists(filePath))
            {
                return candidates;
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var parts = line.Split(',');

                candidates.Add(new Candidate
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    Email = parts[2],
                    PhoneNumber = parts[3],
                    PreferredCallTime = parts[4],
                    LinkedInProfileUrl = parts[5],
                    GitHubProfileUrl = parts[6],
                    Comments = parts[7]
                });
            }

            return candidates;
        }

        public static void WriteCsvFile(string filePath, List<Candidate> candidates)
        {
            var lines = new List<string>
            {
                "FirstName,LastName,Email,PhoneNumber,PreferredCallTime,LinkedInProfileUrl,GitHubProfileUrl,Comments"
            };

            lines.AddRange(candidates.Select(c =>
                $"{c.FirstName},{c.LastName},{c.Email},{c.PhoneNumber},{c.PreferredCallTime},{c.LinkedInProfileUrl},{c.GitHubProfileUrl},{c.Comments}"));

            File.WriteAllLines(filePath, lines);
        }
    }
}
 
