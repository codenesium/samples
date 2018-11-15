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
			                       request.Name);
			return response;
		}

		public virtual ApiBreedClientRequestModel MapClientResponseToRequest(
			ApiBreedClientResponseModel response)
		{
			var request = new ApiBreedClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d3040d5b4ebc2056994ebe2a89b34382</Hash>
</Codenesium>*/