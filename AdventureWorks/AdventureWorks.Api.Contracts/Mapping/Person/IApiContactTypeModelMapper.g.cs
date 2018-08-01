using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiContactTypeModelMapper
	{
		ApiContactTypeResponseModel MapRequestToResponse(
			int contactTypeID,
			ApiContactTypeRequestModel request);

		ApiContactTypeRequestModel MapResponseToRequest(
			ApiContactTypeResponseModel response);

		JsonPatchDocument<ApiContactTypeRequestModel> CreatePatch(ApiContactTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d3195a57411076457187cdae9bbb0e8b</Hash>
</Codenesium>*/