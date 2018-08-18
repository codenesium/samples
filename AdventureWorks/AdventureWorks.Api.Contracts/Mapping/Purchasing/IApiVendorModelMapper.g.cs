using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiVendorModelMapper
	{
		ApiVendorResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiVendorRequestModel request);

		ApiVendorRequestModel MapResponseToRequest(
			ApiVendorResponseModel response);

		JsonPatchDocument<ApiVendorRequestModel> CreatePatch(ApiVendorRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bdc1aaab01ff841ef952f50406762b12</Hash>
</Codenesium>*/