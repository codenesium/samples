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
    <Hash>6cffe9e5347f5a4ed9aeb776ed6dd9e5</Hash>
</Codenesium>*/