using System;
using Microsoft.AspNetCore.Identity;

namespace SecureVideoCRMNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}