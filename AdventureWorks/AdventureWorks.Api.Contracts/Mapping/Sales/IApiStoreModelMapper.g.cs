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
    <Hash>d2fce8b8bd818ecf37e58f4bc4b7e699</Hash>
</Codenesium>*/