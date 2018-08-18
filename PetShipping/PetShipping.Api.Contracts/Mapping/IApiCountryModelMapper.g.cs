using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiCountryModelMapper
	{
		ApiCountryResponseModel MapRequestToResponse(
			int id,
			ApiCountryRequestModel request);

		ApiCountryRequestModel MapResponseToRequest(
			ApiCountryResponseModel response);

		JsonPatchDocument<ApiCountryRequestModel> CreatePatch(ApiCountryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4be49c2df006b4280ea5d75f0bfff0b3</Hash>
</Codenesium>*/