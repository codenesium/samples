using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiHandlerModelMapper
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
    <Hash>a585d18fb72e62d6ad6f9960091fc064</Hash>
</Codenesium>*/