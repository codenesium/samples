using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiSpaceSpaceFeatureModelMapper : IApiSpaceSpaceFeatureModelMapper
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
    <Hash>d2c89788537542f334cd7aed6a033c58</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/