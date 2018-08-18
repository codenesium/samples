using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiContactTypeModelMapper
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
    <Hash>287cb57b3a08eed8143f11bc5c9394ca</Hash>
</Codenesium>*/