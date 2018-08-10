using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiCountryRequirementModelMapper
	{
		ApiCountryRequirementResponseModel MapRequestToResponse(
			int id,
			ApiCountryRequirementRequestModel request);

		ApiCountryRequirementRequestModel MapResponseToRequest(
			ApiCountryRequirementResponseModel response);

		JsonPatchDocument<ApiCountryRequirementRequestModel> CreatePatch(ApiCountryRequirementRequestModel model);
	}
}

/*<Codenesium>
    <Hash>90c380ac4b8ad72d9af8096f6182926e</Hash>
</Codenesium>*/