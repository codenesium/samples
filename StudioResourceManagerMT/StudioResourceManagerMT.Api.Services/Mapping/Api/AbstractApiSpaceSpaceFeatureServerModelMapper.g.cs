using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiSpaceSpaceFeatureServerModelMapper
	{
		public virtual ApiSpaceSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int spaceId,
			ApiSpaceSpaceFeatureServerRequestModel request)
		{
			var response = new ApiSpaceSpaceFeatureServerResponseModel();
			response.SetProperties(spaceId,
			                       request.SpaceFeatureId);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureServerRequestModel();
			request.SetProperties(
				response.SpaceFeatureId);
			return request;
		}

		public virtual ApiSpaceSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.SpaceFeatureId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceSpaceFeatureServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c9aab38412daeee958a56cd3097b2aac</Hash>
</Codenesium>*/