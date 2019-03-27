using System;
using Microsoft.AspNetCore.Identity;

namespace PetShippingNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get;set; }
    }
}