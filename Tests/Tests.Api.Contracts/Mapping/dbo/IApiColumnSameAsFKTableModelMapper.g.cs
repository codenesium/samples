using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiColumnSameAsFKTableModelMapper
	{
		ApiColumnSameAsFKTableResponseModel MapRequestToResponse(
			int id,
			ApiColumnSameAsFKTableRequestModel request);

		ApiColumnSameAsFKTableRequestModel MapResponseToRequest(
			ApiColumnSameAsFKTableResponseModel response);

		JsonPatchDocument<ApiColumnSameAsFKTableRequestModel> CreatePatch(ApiColumnSameAsFKTableRequestModel model);
	}
}

/*<Codenesium>
    <Hash>013fb04f4ceb727692180956941dd4ae</Hash>
</Codenesium>*/