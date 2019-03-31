using System;
using Microsoft.AspNetCore.Identity;

namespace TicketingCRMNS.Api.DataAccess
{
    public class AuthUser : IdentityUser
    {
		public string NewEmail{ get; set; }
    }
}