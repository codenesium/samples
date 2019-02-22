using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOfficerRefCapabilityModelMapper
	{
		ApiOfficerRefCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerRefCapabilityClientRequestModel request);

		ApiOfficerRefCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOfficerRefCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>94b2d84a0a01990993f15f2bbca2dfe3</Hash>
</Codenesium>*/