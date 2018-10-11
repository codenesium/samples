using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiSpaceSpaceFeatureModelMapper
	{
		public virtual ApiSpaceSpaceFeatureResponseModel MapRequestToResponse(
			int spaceId,
			ApiSpaceSpaceFeatureRequestModel request)
		{
			var response = new ApiSpaceSpaceFeatureResponseModel();
			response.SetProperties(spaceId,
			                       request.SpaceFeatureId);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureRequestModel();
			request.SetProperties(
				response.SpaceFeatureId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> CreatePatch(ApiSpaceSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cae79450df24e9a9ee4e401c402f9fa1</Hash>
</Codenesium>*/