using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiTenantServerModelMapper
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
    <Hash>54e792997ae5fd3fc3b4bda88c6165d0</Hash>
</Codenesium>*/