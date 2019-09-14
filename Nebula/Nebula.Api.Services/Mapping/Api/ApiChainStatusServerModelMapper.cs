using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiChainStatusServerModelMapper : IApiChainStatusServerModelMapper
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
    <Hash>e1e76e3f489ea9c4ddbecbc811cec658</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/