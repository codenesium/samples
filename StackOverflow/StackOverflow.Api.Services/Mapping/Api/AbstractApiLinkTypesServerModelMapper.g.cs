using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiLinkTypesServerModelMapper
	{
		public virtual ApiLinkTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkTypesServerRequestModel request)
		{
			var response = new ApiLinkTypesServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiLinkTypesServerRequestModel MapServerResponseToRequest(
			ApiLinkTypesServerResponseModel response)
		{
			var request = new ApiLinkTypesServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiLinkTypesClientRequestModel MapServerResponseToClientRequest(
			ApiLinkTypesServerResponseModel response)
		{
			var request = new ApiLinkTypesClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiLinkTypesServerRequestModel> CreatePatch(ApiLinkTypesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkTypesServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b607529eeaf12d5d7a07d4ed739e186e</Hash>
</Codenesium>*/