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
			                       request.SpaceFeatureId,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> CreatePatch(ApiSpaceSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e50a0ab32acdb125e1f67ea7c0bf929d</Hash>
</Codenesium>*/