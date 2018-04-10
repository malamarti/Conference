using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Models {
    public class ConferenceUser {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
