using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiClientModelMapper
	{
		public virtual ApiClientClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClientClientRequestModel request)
		{
			var response = new ApiClientClientResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Note,
			                       request.Phone);
			return response;
		}

		public virtual ApiClientClientRequestModel MapClientResponseToRequest(
			ApiClientClientResponseModel response)
		{
			var request = new ApiClientClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Note,
				response.Phone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f15ee3db156b2e841bcec77ac1a345e3</Hash>
</Codenesium>*/