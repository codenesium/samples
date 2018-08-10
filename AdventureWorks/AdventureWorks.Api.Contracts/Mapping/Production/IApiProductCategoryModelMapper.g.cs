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
    <Hash>487172a2680b51b851a2d886a6dc4c15</Hash>
</Codenesium>*/