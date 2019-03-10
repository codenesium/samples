using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
    public class AuthenticateRequestModel
    {
		public string Email { get; set; }

		public string Password { get; set; }

		public void SetProperties(string email, string password)
		{
			this.Email = email;
			this.Password = password;
		}
	}
}
