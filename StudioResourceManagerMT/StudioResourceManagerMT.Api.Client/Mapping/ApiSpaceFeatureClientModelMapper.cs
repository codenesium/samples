using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>81d9928ef5f80f44e54092b614bdf9f1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/