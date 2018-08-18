using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductInventoryModelMapper
	{
		ApiProductInventoryResponseModel MapRequestToResponse(
			int productID,
			ApiProductInventoryRequestModel request);

		ApiProductInventoryRequestModel MapResponseToRequest(
			ApiProductInventoryResponseModel response);

		JsonPatchDocument<ApiProductInventoryRequestModel> CreatePatch(ApiProductInventoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7de648717c31ba747fbf6fdcf98b98f8</Hash>
</Codenesium>*/