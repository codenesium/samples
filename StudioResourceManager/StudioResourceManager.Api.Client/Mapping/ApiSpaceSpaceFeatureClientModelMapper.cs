using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>845cf0e22f6c14f32a3f4af20d84140e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/