using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSBI_test.Areas.Identity.Data
{
    public class Manager : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string SurName { get; set; }
        [PersonalData]
        public string Position { get; set; }
    }
}
