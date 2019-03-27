using System;
using Microsoft.AspNetCore.Identity;

namespace ESPIOTNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail { get; set; }
    }
}