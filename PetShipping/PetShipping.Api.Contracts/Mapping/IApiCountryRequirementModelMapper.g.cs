using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiCountryRequirementModelMapper
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
    <Hash>2481db8148af131e84a5963e1ed7e9c5</Hash>
</Codenesium>*/