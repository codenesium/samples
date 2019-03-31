using System;
using Microsoft.AspNetCore.Identity;

namespace PetStoreNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get; set; }
    }
}