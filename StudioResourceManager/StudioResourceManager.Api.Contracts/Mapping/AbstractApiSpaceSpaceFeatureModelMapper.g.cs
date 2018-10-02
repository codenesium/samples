using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiSpaceSpaceFeatureModelMapper
	{
		public virtual ApiSpaceSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureRequestModel request)
		{
			var response = new ApiSpaceSpaceFeatureResponseModel();
			response.SetProperties(id,
			                       request.SpaceFeatureId,
			                       request.SpaceId);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.SpaceId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> CreatePatch(ApiSpaceSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			patch.Replace(x => x.SpaceId, model.SpaceId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c6ab281629a7e3cbb3b88e4c566e46d2</Hash>
</Codenesium>*/