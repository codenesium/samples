using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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
    <Hash>af6c2e8b3fa33117bf2a2397d46f5d6c</Hash>
</Codenesium>*/