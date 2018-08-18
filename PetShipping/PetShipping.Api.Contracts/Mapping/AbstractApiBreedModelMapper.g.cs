using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiBreedModelMapper
	{
		public virtual ApiBreedResponseModel MapRequestToResponse(
			int id,
			ApiBreedRequestModel request)
		{
			var response = new ApiBreedResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.SpeciesId);
			return response;
		}

		public virtual ApiBreedRequestModel MapResponseToRequest(
			ApiBreedResponseModel response)
		{
			var request = new ApiBreedRequestModel();
			request.SetProperties(
				response.Name,
				response.SpeciesId);
			return request;
		}

		public JsonPatchDocument<ApiBreedRequestModel> CreatePatch(ApiBreedRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBreedRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.SpeciesId, model.SpeciesId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>848cdd450613529e63d4e29bfcc6d671</Hash>
</Codenesium>*/