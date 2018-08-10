using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
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
    <Hash>7c5ddf840827a6405e150bfc145290d5</Hash>
</Codenesium>*/