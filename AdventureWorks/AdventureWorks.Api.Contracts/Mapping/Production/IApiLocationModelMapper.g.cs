using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiLocationModelMapper
	{
		ApiLocationResponseModel MapRequestToResponse(
			short locationID,
			ApiLocationRequestModel request);

		ApiLocationRequestModel MapResponseToRequest(
			ApiLocationResponseModel response);

		JsonPatchDocument<ApiLocationRequestModel> CreatePatch(ApiLocationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c48567caf2c77a0f28a2305b2d57018f</Hash>
</Codenesium>*/