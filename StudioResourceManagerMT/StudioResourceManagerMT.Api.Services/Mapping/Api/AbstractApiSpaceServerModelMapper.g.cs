using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>867dc00a6481b488e5a3ca3d878d86fe</Hash>
</Codenesium>*/