using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkStatusServerModelMapper : IApiLinkStatusServerModelMapper
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
    <Hash>005f3e5ba128cbd869385f41344eb095</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/