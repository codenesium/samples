using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiCountryRequirementModelMapper
	{
		ApiCountryRequirementClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCountryRequirementClientRequestModel request);

		ApiCountryRequirementClientRequestModel MapClientResponseToRequest(
			ApiCountryRequirementClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1b1576e5e8e20ffae21bc9e050dccda5</Hash>
</Codenesium>*/