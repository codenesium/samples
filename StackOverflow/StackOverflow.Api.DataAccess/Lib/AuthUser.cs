using System;
using Microsoft.AspNetCore.Identity;

namespace StackOverflowNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get; set; }
    }
}