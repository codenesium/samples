using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiLinkTypeServerModelMapper : IApiLinkTypeServerModelMapper
	{
		public virtual ApiLinkTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkTypeServerRequestModel request)
		{
			var response = new ApiLinkTypeServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiLinkTypeServerRequestModel MapServerResponseToRequest(
			ApiLinkTypeServerResponseModel response)
		{
			var request = new ApiLinkTypeServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiLinkTypeClientRequestModel MapServerResponseToClientRequest(
			ApiLinkTypeServerResponseModel response)
		{
			var request = new ApiLinkTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiLinkTypeServerRequestModel> CreatePatch(ApiLinkTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkTypeServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b3c2142921409e0bdc219dca3859c815</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/