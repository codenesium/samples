using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
    public class ConfirmPasswordResetRequestModel
    {
		public string Id { get; set; }

		public string Token { get; set; }

		public string NewPassword { get; set; }
    }
}
