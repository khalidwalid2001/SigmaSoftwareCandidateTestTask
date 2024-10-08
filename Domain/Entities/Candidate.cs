﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Candidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredCallTime { get; set; }
        public string LinkedInProfileUrl { get; set; }
        public string GitHubProfileUrl { get; set; }
        public string Comments { get; set; }
    }
}
