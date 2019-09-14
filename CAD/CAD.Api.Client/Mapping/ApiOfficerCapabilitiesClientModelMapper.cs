using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiOfficerCapabilitiesModelMapper : IApiOfficerCapabilitiesModelMapper
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
    <Hash>b9094ae84ab6061342848aed1dd15dd5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/