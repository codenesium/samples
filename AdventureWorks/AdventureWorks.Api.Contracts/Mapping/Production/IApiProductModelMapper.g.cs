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
    <Hash>47aa9a3294fd9fa66e88939c57a2be5f</Hash>
</Codenesium>*/