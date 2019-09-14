using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiSpaceFeatureModelMapper : IApiSpaceFeatureModelMapper
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
    <Hash>3b14bada5f17c010ca14d05a4d3b0d10</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/