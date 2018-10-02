using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiLinkTypeModelMapper
	{
		public virtual ApiLinkTypeResponseModel MapRequestToResponse(
			int id,
			ApiLinkTypeRequestModel request)
		{
			var response = new ApiLinkTypeResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiLinkTypeRequestModel MapResponseToRequest(
			ApiLinkTypeResponseModel response)
		{
			var request = new ApiLinkTypeRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiLinkTypeRequestModel> CreatePatch(ApiLinkTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkTypeRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>15cc4d2b2ae41deb90bb0d342d522bbd</Hash>
</Codenesium>*/