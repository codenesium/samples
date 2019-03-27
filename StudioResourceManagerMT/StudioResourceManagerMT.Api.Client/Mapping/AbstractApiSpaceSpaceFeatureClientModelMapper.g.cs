using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiSpaceSpaceFeatureModelMapper
	{
		public virtual ApiSpaceSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int spaceId,
			ApiSpaceSpaceFeatureClientRequestModel request)
		{
			var response = new ApiSpaceSpaceFeatureClientResponseModel();
			response.SetProperties(spaceId,
			                       request.SpaceFeatureId);
			return response;
		}

		public virtual ApiSpaceSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceSpaceFeatureClientResponseModel response)
		{
			var request = new ApiSpaceSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.SpaceFeatureId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c9849d9f4ca9895f120d9e630b50553e</Hash>
</Codenesium>*/