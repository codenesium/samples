using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkStatusServerModelMapper
	{
		public virtual ApiLinkStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkStatusServerRequestModel request)
		{
			var response = new ApiLinkStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiLinkStatusServerRequestModel MapServerResponseToRequest(
			ApiLinkStatusServerResponseModel response)
		{
			var request = new ApiLinkStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiLinkStatusClientRequestModel MapServerResponseToClientRequest(
			ApiLinkStatusServerResponseModel response)
		{
			var request = new ApiLinkStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiLinkStatusServerRequestModel> CreatePatch(ApiLinkStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d5042f134793e42afccbba358e26ffcb</Hash>
</Codenesium>*/