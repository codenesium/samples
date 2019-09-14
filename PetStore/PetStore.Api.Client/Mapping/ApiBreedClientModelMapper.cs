using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public class ApiBreedModelMapper : IApiBreedModelMapper
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
    <Hash>da1e685e2221cddaa95c90867c6bf6bd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/