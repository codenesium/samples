using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiOffCapabilityServerModelMapper
	{
		public virtual ApiOffCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOffCapabilityServerRequestModel request)
		{
			var response = new ApiOffCapabilityServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOffCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOffCapabilityServerResponseModel response)
		{
			var request = new ApiOffCapabilityServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiOffCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOffCapabilityServerResponseModel response)
		{
			var request = new ApiOffCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiOffCapabilityServerRequestModel> CreatePatch(ApiOffCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOffCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5a1e1cef8acc735b2aeb0e37b952a39f</Hash>
</Codenesium>*/