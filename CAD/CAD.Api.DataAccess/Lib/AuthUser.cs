using System;
using Microsoft.AspNetCore.Identity;

namespace CADNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get; set; }
    }
}