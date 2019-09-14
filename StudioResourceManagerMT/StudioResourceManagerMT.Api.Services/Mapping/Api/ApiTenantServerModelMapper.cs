using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiTenantServerModelMapper : IApiTenantServerModelMapper
	{
		public virtual ApiTenantServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTenantServerRequestModel request)
		{
			var response = new ApiTenantServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTenantServerRequestModel MapServerResponseToRequest(
			ApiTenantServerResponseModel response)
		{
			var request = new ApiTenantServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTenantClientRequestModel MapServerResponseToClientRequest(
			ApiTenantServerResponseModel response)
		{
			var request = new ApiTenantClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTenantServerRequestModel> CreatePatch(ApiTenantServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTenantServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5a0bfe664b0f2c8b1ab03a5027b6292d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/