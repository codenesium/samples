using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiBreedServerModelMapper : IApiBreedServerModelMapper
	{
		public virtual ApiBreedServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBreedServerRequestModel request)
		{
			var response = new ApiBreedServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.SpeciesId);
			return response;
		}

		public virtual ApiBreedServerRequestModel MapServerResponseToRequest(
			ApiBreedServerResponseModel response)
		{
			var request = new ApiBreedServerRequestModel();
			request.SetProperties(
				response.Name,
				response.SpeciesId);
			return request;
		}

		public virtual ApiBreedClientRequestModel MapServerResponseToClientRequest(
			ApiBreedServerResponseModel response)
		{
			var request = new ApiBreedClientRequestModel();
			request.SetProperties(
				response.Name,
				response.SpeciesId);
			return request;
		}

		public JsonPatchDocument<ApiBreedServerRequestModel> CreatePatch(ApiBreedServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBreedServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.SpeciesId, model.SpeciesId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>de19505fbb0094283da6a58c9364f881</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/