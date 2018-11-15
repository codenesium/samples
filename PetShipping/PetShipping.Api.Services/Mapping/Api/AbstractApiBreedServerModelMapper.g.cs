using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiBreedServerModelMapper
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
    <Hash>b3270417839b0af39375d731b6f9fe4b</Hash>
</Codenesium>*/