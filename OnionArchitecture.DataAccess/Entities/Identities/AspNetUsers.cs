using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;


namespace OnionArchitecture.DataAccess.Entities.Identities
{
    public class AspNetUsers:IdentityUser
    {
        public string WebSite { get; set; }
    }
}
