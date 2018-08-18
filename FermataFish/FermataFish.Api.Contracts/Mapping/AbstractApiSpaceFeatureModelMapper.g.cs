using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiSpaceFeatureModelMapper
	{
		public virtual ApiSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceFeatureRequestModel request)
		{
			var response = new ApiSpaceFeatureResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.StudioId);
			return response;
		}

		public virtual ApiSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceFeatureRequestModel();
			request.SetProperties(
				response.Name,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiSpaceFeatureRequestModel> CreatePatch(ApiSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceFeatureRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f0024406463cd7840c7fe142709cfe16</Hash>
</Codenesium>*/