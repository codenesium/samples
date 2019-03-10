using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
    public class RegisterResponseModel
    {
		public bool Success { get; private set; }

		public string ErrorCode { get; private set; }

		public string ErrorMessage { get; private set; }


		public void SetPropertiesSuccess()
		{
			this.Success = true; 
		}

		public void SetPropertiesFailure(string errorCode, string errorMessage)
		{
			this.Success = false;
			this.ErrorCode = errorCode;
			this.ErrorMessage = errorMessage;
		}
	}
}
