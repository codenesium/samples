using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiPersonTypeServerModelMapper : IApiPersonTypeServerModelMapper
	{
		public virtual ApiPersonTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonTypeServerRequestModel request)
		{
			var response = new ApiPersonTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPersonTypeServerRequestModel MapServerResponseToRequest(
			ApiPersonTypeServerResponseModel response)
		{
			var request = new ApiPersonTypeServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPersonTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPersonTypeServerResponseModel response)
		{
			var request = new ApiPersonTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPersonTypeServerRequestModel> CreatePatch(ApiPersonTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonTypeServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>14e9102961a19ef74ba4bdccb6db42b8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/