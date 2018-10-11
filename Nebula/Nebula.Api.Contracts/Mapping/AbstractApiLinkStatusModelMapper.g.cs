using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiLinkStatusModelMapper
	{
		public virtual ApiLinkStatusResponseModel MapRequestToResponse(
			int id,
			ApiLinkStatusRequestModel request)
		{
			var response = new ApiLinkStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiLinkStatusRequestModel MapResponseToRequest(
			ApiLinkStatusResponseModel response)
		{
			var request = new ApiLinkStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiLinkStatusRequestModel> CreatePatch(ApiLinkStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ad18865b7d37a965b8d90273bde04351</Hash>
</Codenesium>*/