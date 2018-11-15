using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiOrganizationServerModelMapper
	{
		public virtual ApiOrganizationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOrganizationServerRequestModel request)
		{
			var response = new ApiOrganizationServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOrganizationServerRequestModel MapServerResponseToRequest(
			ApiOrganizationServerResponseModel response)
		{
			var request = new ApiOrganizationServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiOrganizationClientRequestModel MapServerResponseToClientRequest(
			ApiOrganizationServerResponseModel response)
		{
			var request = new ApiOrganizationClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiOrganizationServerRequestModel> CreatePatch(ApiOrganizationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOrganizationServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3e92e9af5aa7a2d6a28f61f7df5759e3</Hash>
</Codenesium>*/