using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductModelModelMapper
	{
		ApiProductModelResponseModel MapRequestToResponse(
			int productModelID,
			ApiProductModelRequestModel request);

		ApiProductModelRequestModel MapResponseToRequest(
			ApiProductModelResponseModel response);

		JsonPatchDocument<ApiProductModelRequestModel> CreatePatch(ApiProductModelRequestModel model);
	}
}

/*<Codenesium>
    <Hash>456dc2ec51a4300d679b4392ff89a475</Hash>
</Codenesium>*/