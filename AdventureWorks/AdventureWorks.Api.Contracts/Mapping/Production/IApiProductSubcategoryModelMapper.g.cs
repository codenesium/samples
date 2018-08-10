using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductSubcategoryModelMapper
	{
		ApiProductSubcategoryResponseModel MapRequestToResponse(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel request);

		ApiProductSubcategoryRequestModel MapResponseToRequest(
			ApiProductSubcategoryResponseModel response);

		JsonPatchDocument<ApiProductSubcategoryRequestModel> CreatePatch(ApiProductSubcategoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1e6eb8b461c8689189ae26176b56f685</Hash>
</Codenesium>*/