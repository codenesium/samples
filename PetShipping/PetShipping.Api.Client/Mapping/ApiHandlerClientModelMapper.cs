using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiHandlerModelMapper : IApiHandlerModelMapper
	{
		public virtual ApiHandlerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiHandlerClientRequestModel request)
		{
			var response = new ApiHandlerClientResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone);
			return response;
		}

		public virtual ApiHandlerClientRequestModel MapClientResponseToRequest(
			ApiHandlerClientResponseModel response)
		{
			var request = new ApiHandlerClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2977c7c69498251a9db17f362aed45ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/