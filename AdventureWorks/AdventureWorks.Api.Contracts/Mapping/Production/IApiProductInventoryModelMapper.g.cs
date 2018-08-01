using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductInventoryModelMapper
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
    <Hash>ab2fa0022fda36d92fb38962be9fdd6d</Hash>
</Codenesium>*/