using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiBusinessEntityContactModelMapper
	{
		ApiBusinessEntityContactResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel request);

		ApiBusinessEntityContactRequestModel MapResponseToRequest(
			ApiBusinessEntityContactResponseModel response);

		JsonPatchDocument<ApiBusinessEntityContactRequestModel> CreatePatch(ApiBusinessEntityContactRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3f75f4b8ee4bb167e4283729f8460c84</Hash>
</Codenesium>*/