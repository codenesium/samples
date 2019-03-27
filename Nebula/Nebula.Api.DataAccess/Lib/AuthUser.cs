using System;
using Microsoft.AspNetCore.Identity;

namespace NebulaNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}