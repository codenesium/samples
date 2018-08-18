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
    <Hash>322504a64e6c9c30b644b2afd92bcf66</Hash>
</Codenesium>*/