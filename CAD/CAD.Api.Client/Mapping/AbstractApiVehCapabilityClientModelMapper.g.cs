using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehCapabilityModelMapper
	{
		public virtual ApiVehCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehCapabilityClientRequestModel request)
		{
			var response = new ApiVehCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehCapabilityClientResponseModel response)
		{
			var request = new ApiVehCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2deae4b2d1a4248d227094696f33c140</Hash>
</Codenesium>*/