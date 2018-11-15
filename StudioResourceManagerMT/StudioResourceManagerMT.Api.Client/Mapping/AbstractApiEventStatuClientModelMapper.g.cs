using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>522f15c3f66d8310d350f1305c3c127d</Hash>
</Codenesium>*/