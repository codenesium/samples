using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiSpaceXSpaceFeatureModelMapper
	{
		public virtual ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceXSpaceFeatureRequestModel request)
		{
			var response = new ApiSpaceXSpaceFeatureResponseModel();
			response.SetProperties(id,
			                       request.SpaceFeatureId,
			                       request.SpaceId,
			                       request.StudioId);
			return response;
		}

		public virtual ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceXSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceXSpaceFeatureRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.SpaceId,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> CreatePatch(ApiSpaceXSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, model.SpaceFeatureId);
			patch.Replace(x => x.SpaceId, model.SpaceId);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>24574d172672e76c97807e9f36337195</Hash>
</Codenesium>*/