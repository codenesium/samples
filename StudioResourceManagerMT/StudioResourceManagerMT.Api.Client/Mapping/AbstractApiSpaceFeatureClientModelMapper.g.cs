using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiSpaceFeatureModelMapper
	{
		public virtual ApiSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceFeatureClientRequestModel request)
		{
			var response = new ApiSpaceFeatureClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceFeatureClientResponseModel response)
		{
			var request = new ApiSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d507e0e990b21d326fd02b9a3bde6509</Hash>
</Codenesium>*/