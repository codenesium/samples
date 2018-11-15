using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiSpeciesModelMapper
	{
		public virtual ApiSpeciesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpeciesClientRequestModel request)
		{
			var response = new ApiSpeciesClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpeciesClientRequestModel MapClientResponseToRequest(
			ApiSpeciesClientResponseModel response)
		{
			var request = new ApiSpeciesClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>de13e25f33cecd64e92d619cd0eae103</Hash>
</Codenesium>*/