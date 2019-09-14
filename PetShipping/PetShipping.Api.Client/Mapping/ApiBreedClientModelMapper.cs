using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>2db08e6acb880bf9d014255349af944d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/