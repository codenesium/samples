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
    <Hash>fe2c72db1a914b70154a8b5566b92eac</Hash>
</Codenesium>*/