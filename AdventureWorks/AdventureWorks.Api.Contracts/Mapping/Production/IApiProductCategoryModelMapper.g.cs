using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductCategoryModelMapper
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
    <Hash>ef89421ceacd39752ff70f22364b010d</Hash>
</Codenesium>*/