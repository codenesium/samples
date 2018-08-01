using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductModelMapper
	{
		ApiProductResponseModel MapRequestToResponse(
			int productID,
			ApiProductRequestModel request);

		ApiProductRequestModel MapResponseToRequest(
			ApiProductResponseModel response);

		JsonPatchDocument<ApiProductRequestModel> CreatePatch(ApiProductRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cff92befe7492fa3c7e673546da7c247</Hash>
</Codenesium>*/