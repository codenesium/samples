using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiBusinessEntityAddressModelMapper
	{
		ApiBusinessEntityAddressResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel request);

		ApiBusinessEntityAddressRequestModel MapResponseToRequest(
			ApiBusinessEntityAddressResponseModel response);

		JsonPatchDocument<ApiBusinessEntityAddressRequestModel> CreatePatch(ApiBusinessEntityAddressRequestModel model);
	}
}

/*<Codenesium>
    <Hash>dd5c50a4ef4662da4f4b8e030508de5c</Hash>
</Codenesium>*/