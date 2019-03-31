using System;
using Microsoft.AspNetCore.Identity;

namespace PointOfSaleNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get; set; }
    }
}