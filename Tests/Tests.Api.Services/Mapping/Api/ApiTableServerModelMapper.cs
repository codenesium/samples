using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiTableServerModelMapper : IApiTableServerModelMapper
	{
		public virtual ApiTableServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTableServerRequestModel request)
		{
			var response = new ApiTableServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTableServerRequestModel MapServerResponseToRequest(
			ApiTableServerResponseModel response)
		{
			var request = new ApiTableServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTableClientRequestModel MapServerResponseToClientRequest(
			ApiTableServerResponseModel response)
		{
			var request = new ApiTableClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTableServerRequestModel> CreatePatch(ApiTableServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTableServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>07b816a96b238a1dbb49904842f5a9ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/