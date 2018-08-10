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
    <Hash>698e735b844ac0ecd76fb5974605caf8</Hash>
</Codenesium>*/