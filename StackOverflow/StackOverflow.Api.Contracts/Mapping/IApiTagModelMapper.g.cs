using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiTagModelMapper
	{
		ApiTagResponseModel MapRequestToResponse(
			int id,
			ApiTagRequestModel request);

		ApiTagRequestModel MapResponseToRequest(
			ApiTagResponseModel response);

		JsonPatchDocument<ApiTagRequestModel> CreatePatch(ApiTagRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b2dca06b86d35a8b381ef23eefa41ea0</Hash>
</Codenesium>*/