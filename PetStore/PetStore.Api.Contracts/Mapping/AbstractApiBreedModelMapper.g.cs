using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public abstract class AbstractApiBreedModelMapper
	{
		public virtual ApiBreedResponseModel MapRequestToResponse(
			int id,
			ApiBreedRequestModel request)
		{
			var response = new ApiBreedResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiBreedRequestModel MapResponseToRequest(
			ApiBreedResponseModel response)
		{
			var request = new ApiBreedRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiBreedRequestModel> CreatePatch(ApiBreedRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBreedRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9c76e984d94c06f930c169bc318115e0</Hash>
</Codenesium>*/