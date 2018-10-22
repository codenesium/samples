using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiSpaceFeatureModelMapper
	{
		public virtual ApiSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceFeatureRequestModel request)
		{
			var response = new ApiSpaceFeatureResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceFeatureRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpaceFeatureRequestModel> CreatePatch(ApiSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceFeatureRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3014e3380096aab989b090a2ae47ab54</Hash>
</Codenesium>*/