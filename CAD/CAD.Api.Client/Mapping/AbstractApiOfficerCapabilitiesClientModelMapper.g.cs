using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOfficerCapabilitiesModelMapper
	{
		public virtual ApiOfficerCapabilitiesClientResponseModel MapClientRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilitiesClientRequestModel request)
		{
			var response = new ApiOfficerCapabilitiesClientResponseModel();
			response.SetProperties(capabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilitiesClientResponseModel response)
		{
			var request = new ApiOfficerCapabilitiesClientRequestModel();
			request.SetProperties(
				response.OfficerId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4edb467cd5cbef7f520a669edabc9d66</Hash>
</Codenesium>*/