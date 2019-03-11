using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESPIOTNS.Api.DataAccess.Auth
{
	public partial class AuthUser : IdentityUser
	{
		public AuthUser()
		{
		}
	}
}
