using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CandidateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredCallTime { get; set; }
        public string LinkedInProfileUrl { get; set; }
        public string GitHubProfileUrl { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}
