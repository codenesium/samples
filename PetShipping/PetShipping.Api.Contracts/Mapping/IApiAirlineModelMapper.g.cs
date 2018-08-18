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
    <Hash>79e867f2f3fcdfee15003e5c6647db21</Hash>
</Codenesium>*/