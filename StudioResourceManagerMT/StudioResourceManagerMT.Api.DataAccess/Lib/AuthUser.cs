using System;
using Microsoft.AspNetCore.Identity;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get; set; }
    }
}