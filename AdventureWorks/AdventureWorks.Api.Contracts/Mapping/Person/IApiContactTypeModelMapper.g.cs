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
    <Hash>159b8e0ac799ec4bc865831c820e0f18</Hash>
</Codenesium>*/