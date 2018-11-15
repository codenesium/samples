using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiSpaceFeatureServerModelMapper
	{
		public virtual ApiSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceFeatureServerRequestModel request)
		{
			var response = new ApiSpaceFeatureServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceFeatureServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceFeatureServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceFeatureServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>92dc13068e3d575004555f47e3c1a77a</Hash>
</Codenesium>*/