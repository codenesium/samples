using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiPersonServerModelMapper : IApiPersonServerModelMapper
	{
		public virtual ApiPersonServerResponseModel MapServerRequestToResponse(
			int personId,
			ApiPersonServerRequestModel request)
		{
			var response = new ApiPersonServerResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonServerRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public virtual ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonServerRequestModel>();
			patch.Replace(x => x.PersonName, model.PersonName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>46616231c9bab953f9e21a25e539ccbc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/