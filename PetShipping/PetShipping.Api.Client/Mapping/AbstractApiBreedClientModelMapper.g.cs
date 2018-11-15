using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiBreedModelMapper
	{
		public virtual ApiBreedClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBreedClientRequestModel request)
		{
			var response = new ApiBreedClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.SpeciesId);
			return response;
		}

		public virtual ApiBreedClientRequestModel MapClientResponseToRequest(
			ApiBreedClientResponseModel response)
		{
			var request = new ApiBreedClientRequestModel();
			request.SetProperties(
				response.Name,
				response.SpeciesId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0e2fa493246976ffd83ae4537418a5d9</Hash>
</Codenesium>*/