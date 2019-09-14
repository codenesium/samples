using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventStatusServerModelMapper : IApiEventStatusServerModelMapper
	{
		public virtual ApiEventStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStatusServerRequestModel request)
		{
			var response = new ApiEventStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatusServerRequestModel MapServerResponseToRequest(
			ApiEventStatusServerResponseModel response)
		{
			var request = new ApiEventStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiEventStatusClientRequestModel MapServerResponseToClientRequest(
			ApiEventStatusServerResponseModel response)
		{
			var request = new ApiEventStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiEventStatusServerRequestModel> CreatePatch(ApiEventStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2b8d7d12d0f21458bd7ad49f463dfa66</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/