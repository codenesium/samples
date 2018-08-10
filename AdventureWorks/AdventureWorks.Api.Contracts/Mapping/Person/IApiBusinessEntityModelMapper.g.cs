using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiBusinessEntityModelMapper
	{
		ApiBusinessEntityResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityRequestModel request);

		ApiBusinessEntityRequestModel MapResponseToRequest(
			ApiBusinessEntityResponseModel response);

		JsonPatchDocument<ApiBusinessEntityRequestModel> CreatePatch(ApiBusinessEntityRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bf4336a4b43b9870f420710fc042dce6</Hash>
</Codenesium>*/