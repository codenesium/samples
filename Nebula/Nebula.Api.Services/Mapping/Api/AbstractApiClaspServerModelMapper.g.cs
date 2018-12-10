using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiClaspServerModelMapper
	{
		public virtual ApiClaspServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClaspServerRequestModel request)
		{
			var response = new ApiClaspServerResponseModel();
			response.SetProperties(id,
			                       request.NextChainId,
			                       request.PreviousChainId);
			return response;
		}

		public virtual ApiClaspServerRequestModel MapServerResponseToRequest(
			ApiClaspServerResponseModel response)
		{
			var request = new ApiClaspServerRequestModel();
			request.SetProperties(
				response.NextChainId,
				response.PreviousChainId);
			return request;
		}

		public virtual ApiClaspClientRequestModel MapServerResponseToClientRequest(
			ApiClaspServerResponseModel response)
		{
			var request = new ApiClaspClientRequestModel();
			request.SetProperties(
				response.NextChainId,
				response.PreviousChainId);
			return request;
		}

		public JsonPatchDocument<ApiClaspServerRequestModel> CreatePatch(ApiClaspServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClaspServerRequestModel>();
			patch.Replace(x => x.NextChainId, model.NextChainId);
			patch.Replace(x => x.PreviousChainId, model.PreviousChainId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8678480526bf24d5efb797a80752e18f</Hash>
</Codenesium>*/