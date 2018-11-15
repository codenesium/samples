using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiBreedServerModelMapper
	{
		public virtual ApiBreedServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBreedServerRequestModel request)
		{
			var response = new ApiBreedServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiBreedServerRequestModel MapServerResponseToRequest(
			ApiBreedServerResponseModel response)
		{
			var request = new ApiBreedServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiBreedClientRequestModel MapServerResponseToClientRequest(
			ApiBreedServerResponseModel response)
		{
			var request = new ApiBreedClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiBreedServerRequestModel> CreatePatch(ApiBreedServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBreedServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4f03f3bdb0d722e9f00a0c8c3a8d39c0</Hash>
</Codenesium>*/