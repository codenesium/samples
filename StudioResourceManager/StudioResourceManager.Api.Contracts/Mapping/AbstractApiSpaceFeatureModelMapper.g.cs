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
			                       request.Name,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceFeatureResponseModel response)
		{
			var request = new ApiSpaceFeatureRequestModel();
			request.SetProperties(
				response.Name,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiSpaceFeatureRequestModel> CreatePatch(ApiSpaceFeatureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceFeatureRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>670f7788964a01359677443643e13eb6</Hash>
</Codenesium>*/