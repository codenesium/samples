using System;
using Microsoft.AspNetCore.Identity;

namespace StudioResourceManagerNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}