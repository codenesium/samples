using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOfficerCapabilityModelMapper
	{
		ApiOfficerCapabilityClientResponseModel MapClientRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilityClientRequestModel request);

		ApiOfficerCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0119b8b1492b624c3c4e88fa28db7ad8</Hash>
</Codenesium>*/