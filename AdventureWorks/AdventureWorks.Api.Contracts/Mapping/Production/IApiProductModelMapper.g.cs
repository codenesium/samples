using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductModelMapper
	{
		ApiProductResponseModel MapRequestToResponse(
			int productID,
			ApiProductRequestModel request);

		ApiProductRequestModel MapResponseToRequest(
			ApiProductResponseModel response);

		JsonPatchDocument<ApiProductRequestModel> CreatePatch(ApiProductRequestModel model);
	}
}

/*<Codenesium>
    <Hash>006e5381e441c0732e19c62a5a5fae9c</Hash>
</Codenesium>*/