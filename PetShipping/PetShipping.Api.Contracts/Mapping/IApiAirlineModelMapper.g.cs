using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiAirlineModelMapper
	{
		ApiAirlineResponseModel MapRequestToResponse(
			int id,
			ApiAirlineRequestModel request);

		ApiAirlineRequestModel MapResponseToRequest(
			ApiAirlineResponseModel response);

		JsonPatchDocument<ApiAirlineRequestModel> CreatePatch(ApiAirlineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>60aa1da94217d583082b808c936ab1be</Hash>
</Codenesium>*/