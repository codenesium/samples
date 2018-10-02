using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostTypeModelMapper
	{
		public virtual ApiPostTypeResponseModel MapRequestToResponse(
			int id,
			ApiPostTypeRequestModel request)
		{
			var response = new ApiPostTypeResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiPostTypeRequestModel MapResponseToRequest(
			ApiPostTypeResponseModel response)
		{
			var request = new ApiPostTypeRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiPostTypeRequestModel> CreatePatch(ApiPostTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostTypeRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>bbeab68c293f9eebb278428ed3a26ea0</Hash>
</Codenesium>*/