using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiLinkStatuModelMapper
	{
		public virtual ApiLinkStatuResponseModel MapRequestToResponse(
			int id,
			ApiLinkStatuRequestModel request)
		{
			var response = new ApiLinkStatuResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiLinkStatuRequestModel MapResponseToRequest(
			ApiLinkStatuResponseModel response)
		{
			var request = new ApiLinkStatuRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiLinkStatuRequestModel> CreatePatch(ApiLinkStatuRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkStatuRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a961a6bd90e57075fe77bb11183faa0b</Hash>
</Codenesium>*/