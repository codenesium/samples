using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOfficerCapabilitiesModelMapper
	{
		public virtual ApiOfficerCapabilitiesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerCapabilitiesClientRequestModel request)
		{
			var response = new ApiOfficerCapabilitiesClientResponseModel();
			response.SetProperties(id,
			                       request.CapabilityId,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiOfficerCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilitiesClientResponseModel response)
		{
			var request = new ApiOfficerCapabilitiesClientRequestModel();
			request.SetProperties(
				response.CapabilityId,
				response.OfficerId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c96b00baf36f7147995e6fd25758c95e</Hash>
</Codenesium>*/