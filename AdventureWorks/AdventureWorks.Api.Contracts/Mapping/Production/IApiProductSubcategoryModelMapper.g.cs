using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductSubcategoryModelMapper
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
    <Hash>ebe2c2187b994e31b3b453eafd9d57c4</Hash>
</Codenesium>*/