using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiStateModelMapper
	{
		public virtual ApiStateResponseModel MapRequestToResponse(
			int id,
			ApiStateRequestModel request)
		{
			var response = new ApiStateResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiStateRequestModel MapResponseToRequest(
			ApiStateResponseModel response)
		{
			var request = new ApiStateRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiStateRequestModel> CreatePatch(ApiStateRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStateRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f4c35d2f3a3bfb4b9b91b10e617ee21b</Hash>
</Codenesium>*/