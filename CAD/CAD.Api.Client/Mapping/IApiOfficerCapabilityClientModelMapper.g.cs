using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOfficerCapabilityModelMapper
	{
		ApiOfficerCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerCapabilityClientRequestModel request);

		ApiOfficerCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOfficerCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b3b222431a616c0c08f8bbba0e91b8a0</Hash>
</Codenesium>*/