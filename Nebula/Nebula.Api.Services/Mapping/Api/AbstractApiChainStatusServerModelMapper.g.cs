using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiChainStatusServerModelMapper
	{
		public virtual ApiChainStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiChainStatusServerRequestModel request)
		{
			var response = new ApiChainStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiChainStatusServerRequestModel MapServerResponseToRequest(
			ApiChainStatusServerResponseModel response)
		{
			var request = new ApiChainStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiChainStatusClientRequestModel MapServerResponseToClientRequest(
			ApiChainStatusServerResponseModel response)
		{
			var request = new ApiChainStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiChainStatusServerRequestModel> CreatePatch(ApiChainStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiChainStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e15ed8b34803ddd14b29f537325f991e</Hash>
</Codenesium>*/