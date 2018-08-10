using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiTableModelMapper
	{
		ApiTableResponseModel MapRequestToResponse(
			int id,
			ApiTableRequestModel request);

		ApiTableRequestModel MapResponseToRequest(
			ApiTableResponseModel response);

		JsonPatchDocument<ApiTableRequestModel> CreatePatch(ApiTableRequestModel model);
	}
}

/*<Codenesium>
    <Hash>512ed7540b980bf275af31bafea18c78</Hash>
</Codenesium>*/