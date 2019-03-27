using System;
using Microsoft.AspNetCore.Identity;

namespace TwitterNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}