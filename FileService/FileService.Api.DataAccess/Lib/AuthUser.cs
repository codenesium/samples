using System;
using Microsoft.AspNetCore.Identity;

namespace FileServiceNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}