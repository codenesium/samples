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
    <Hash>cfe81f3c7bd22251e4f6d87fac3a9501</Hash>
</Codenesium>*/