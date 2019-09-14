using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiSpaceSpaceFeatureServerModelMapper : IApiSpaceSpaceFeatureServerModelMapper
	{
		public virtual ApiSpaceSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureServerRequestModel request)
		{
			var response = new ApiSpaceSpaceFeatureServerResponseModel();
			response.SetProperties(id,
			                       request.SpaceFeatureId,
			                       request.SpaceId);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureServerRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.SpaceId);
			return request;
		}

		public virtual ApiSpaceSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.SpaceId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceSpaceFeatureServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			patch.Replace(x => x.SpaceId, model.SpaceId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>11504c5e0ceab5829ec0f717936b5bcf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/