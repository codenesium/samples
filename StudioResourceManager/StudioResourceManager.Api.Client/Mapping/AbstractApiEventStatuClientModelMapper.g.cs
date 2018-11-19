using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiEventStatuModelMapper
	{
		public virtual ApiEventStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStatuClientRequestModel request)
		{
			var response = new ApiEventStatuClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatuClientRequestModel MapClientResponseToRequest(
			ApiEventStatuClientResponseModel response)
		{
			var request = new ApiEventStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5af878f34dabdaf6b19e5e3101ffa9c6</Hash>
</Codenesium>*/