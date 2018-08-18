using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiSpeciesModelMapper
	{
		public virtual ApiSpeciesResponseModel MapRequestToResponse(
			int id,
			ApiSpeciesRequestModel request)
		{
			var response = new ApiSpeciesResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpeciesRequestModel MapResponseToRequest(
			ApiSpeciesResponseModel response)
		{
			var request = new ApiSpeciesRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpeciesRequestModel> CreatePatch(ApiSpeciesRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpeciesRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>058c3660a72db3c675590bd892f767c7</Hash>
</Codenesium>*/