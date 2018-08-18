using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiStoreModelMapper
	{
		ApiStoreResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiStoreRequestModel request);

		ApiStoreRequestModel MapResponseToRequest(
			ApiStoreResponseModel response);

		JsonPatchDocument<ApiStoreRequestModel> CreatePatch(ApiStoreRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3a0e13f34073ace41afb627c313ec9d3</Hash>
</Codenesium>*/