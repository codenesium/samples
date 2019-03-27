using System;
using Microsoft.AspNetCore.Identity;

namespace TestsNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}