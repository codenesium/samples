using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiSpaceSpaceFeatureModelMapper
	{
		public virtual ApiSpaceSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureClientRequestModel request)
		{
			var response = new ApiSpaceSpaceFeatureClientResponseModel();
			response.SetProperties(id,
			                       request.SpaceFeatureId,
			                       request.SpaceId);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceSpaceFeatureClientResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.SpaceFeatureId,
				response.SpaceId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>6325655b2f8e95c9fd5ce717a75ddd8a</Hash>
</Codenesium>*/