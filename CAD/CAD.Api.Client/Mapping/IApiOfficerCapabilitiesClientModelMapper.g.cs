using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOfficerCapabilitiesModelMapper
	{
		ApiOfficerCapabilitiesClientResponseModel MapClientRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilitiesClientRequestModel request);

		ApiOfficerCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilitiesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>60001f0ea1152632c7c0e0c215c1fff7</Hash>
</Codenesium>*/