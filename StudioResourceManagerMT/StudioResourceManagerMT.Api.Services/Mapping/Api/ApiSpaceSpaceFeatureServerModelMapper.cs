using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>6d7ba4532f8fb441581daa8fe3591906</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/