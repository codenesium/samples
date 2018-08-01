using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiVendorModelMapper
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
    <Hash>df5f741fb62de9faa2c5bfdf023039e8</Hash>
</Codenesium>*/