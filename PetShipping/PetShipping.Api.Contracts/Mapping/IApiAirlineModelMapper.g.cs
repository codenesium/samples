using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiAirlineModelMapper
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
    <Hash>6096af287cdfc355105b6676027faebe</Hash>
</Codenesium>*/