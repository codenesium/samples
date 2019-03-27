using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOfficerCapabilitiesModelMapper
	{
		ApiOfficerCapabilitiesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerCapabilitiesClientRequestModel request);

		ApiOfficerCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilitiesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>bc6ecb1466318096a1c47fbd57d8d116</Hash>
</Codenesium>*/