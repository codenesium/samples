using PetShippingNS.Api.Contracts;
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
    <Hash>da7113f541e28f80d30d3a209c39d1f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/