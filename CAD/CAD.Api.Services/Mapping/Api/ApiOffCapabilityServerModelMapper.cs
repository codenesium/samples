using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOffCapabilityServerModelMapper : IApiOffCapabilityServerModelMapper
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
    <Hash>5d8f1f8a04cc912b3d90f8cc08227b46</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/