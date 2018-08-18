using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductCategoryModelMapper
	{
		ApiProductCategoryResponseModel MapRequestToResponse(
			int productCategoryID,
			ApiProductCategoryRequestModel request);

		ApiProductCategoryRequestModel MapResponseToRequest(
			ApiProductCategoryResponseModel response);

		JsonPatchDocument<ApiProductCategoryRequestModel> CreatePatch(ApiProductCategoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cfed6d98ddc8356fc10019f0280eaa01</Hash>
</Codenesium>*/