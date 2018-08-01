using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiStoreModelMapper
	{
		ApiStoreResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiStoreRequestModel request);

		ApiStoreRequestModel MapResponseToRequest(
			ApiStoreResponseModel response);

		JsonPatchDocument<ApiStoreRequestModel> CreatePatch(ApiStoreRequestModel model);
	}
}

/*<Codenesium>
    <Hash>47ad93e9706a330a155ea43402a9efdc</Hash>
</Codenesium>*/