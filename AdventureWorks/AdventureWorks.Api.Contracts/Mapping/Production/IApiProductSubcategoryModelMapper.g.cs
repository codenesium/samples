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
    <Hash>ddf70cd55250108ab13d4862cbd034d1</Hash>
</Codenesium>*/