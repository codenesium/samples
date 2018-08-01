using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductVendorModelMapper
	{
		ApiProductVendorResponseModel MapRequestToResponse(
			int productID,
			ApiProductVendorRequestModel request);

		ApiProductVendorRequestModel MapResponseToRequest(
			ApiProductVendorResponseModel response);

		JsonPatchDocument<ApiProductVendorRequestModel> CreatePatch(ApiProductVendorRequestModel model);
	}
}

/*<Codenesium>
    <Hash>00674b7c69d952e6ffebdd40d07e5797</Hash>
</Codenesium>*/