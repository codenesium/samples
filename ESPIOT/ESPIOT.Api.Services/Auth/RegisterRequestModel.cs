using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
    public class RegisterRequestModel
    {
		public string Email { get; set; }

		public string Password { get; set; }
    }
}
