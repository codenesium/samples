using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiChainServerModelMapper : IApiChainServerModelMapper
	{
		public virtual ApiChainServerResponseModel MapServerRequestToResponse(
			int id,
			ApiChainServerRequestModel request)
		{
			var response = new ApiChainServerResponseModel();
			response.SetProperties(id,
			                       request.ChainStatusId,
			                       request.ExternalId,
			                       request.Name,
			                       request.TeamId);
			return response;
		}

		public virtual ApiChainServerRequestModel MapServerResponseToRequest(
			ApiChainServerResponseModel response)
		{
			var request = new ApiChainServerRequestModel();
			request.SetProperties(
				response.ChainStatusId,
				response.ExternalId,
				response.Name,
				response.TeamId);
			return request;
		}

		public virtual ApiChainClientRequestModel MapServerResponseToClientRequest(
			ApiChainServerResponseModel response)
		{
			var request = new ApiChainClientRequestModel();
			request.SetProperties(
				response.ChainStatusId,
				response.ExternalId,
				response.Name,
				response.TeamId);
			return request;
		}

		public JsonPatchDocument<ApiChainServerRequestModel> CreatePatch(ApiChainServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiChainServerRequestModel>();
			patch.Replace(x => x.ChainStatusId, model.ChainStatusId);
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.TeamId, model.TeamId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c292573d357def8791a898b1e90ae1e9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/