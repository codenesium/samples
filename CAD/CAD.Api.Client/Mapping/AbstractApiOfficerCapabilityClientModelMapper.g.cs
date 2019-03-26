using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOfficerCapabilityModelMapper
	{
		public virtual ApiOfficerCapabilityClientResponseModel MapClientRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilityClientRequestModel request)
		{
			var response = new ApiOfficerCapabilityClientResponseModel();
			response.SetProperties(capabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilityClientResponseModel response)
		{
			var request = new ApiOfficerCapabilityClientRequestModel();
			request.SetProperties(
				response.OfficerId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0c669dbb83d7036be036ebdbd2660d05</Hash>
</Codenesium>*/