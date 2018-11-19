using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiSpaceServerModelMapper
	{
		public virtual ApiSpaceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceServerRequestModel request)
		{
			var response = new ApiSpaceServerResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceServerRequestModel MapServerResponseToRequest(
			ApiSpaceServerResponseModel response)
		{
			var request = new ApiSpaceServerRequestModel();
			request.SetProperties(
				response.Description,
				response.Name);
			return request;
		}

		public virtual ApiSpaceClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceServerResponseModel response)
		{
			var request = new ApiSpaceClientRequestModel();
			request.SetProperties(
				response.Description,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpaceServerRequestModel> CreatePatch(ApiSpaceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceServerRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e95a3c01c18b77f67923d000031b2351</Hash>
</Codenesium>*/