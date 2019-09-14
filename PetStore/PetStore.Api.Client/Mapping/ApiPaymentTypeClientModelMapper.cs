using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public class ApiPaymentTypeModelMapper : IApiPaymentTypeModelMapper
	{
		public virtual ApiPaymentTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPaymentTypeClientRequestModel request)
		{
			var response = new ApiPaymentTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPaymentTypeClientRequestModel MapClientResponseToRequest(
			ApiPaymentTypeClientResponseModel response)
		{
			var request = new ApiPaymentTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>fe111d761869e5266fecfba14358e5a6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/