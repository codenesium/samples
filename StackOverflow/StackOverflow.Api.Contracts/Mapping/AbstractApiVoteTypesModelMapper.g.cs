using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiVoteTypesModelMapper
	{
		public virtual ApiVoteTypesResponseModel MapRequestToResponse(
			int id,
			ApiVoteTypesRequestModel request)
		{
			var response = new ApiVoteTypesResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVoteTypesRequestModel MapResponseToRequest(
			ApiVoteTypesResponseModel response)
		{
			var request = new ApiVoteTypesRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVoteTypesRequestModel> CreatePatch(ApiVoteTypesRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVoteTypesRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8a79632df78bd7a3bea643c6e46dae77</Hash>
</Codenesium>*/