using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductDescriptionModelMapper
	{
		ApiProductDescriptionResponseModel MapRequestToResponse(
			int productDescriptionID,
			ApiProductDescriptionRequestModel request);

		ApiProductDescriptionRequestModel MapResponseToRequest(
			ApiProductDescriptionResponseModel response);

		JsonPatchDocument<ApiProductDescriptionRequestModel> CreatePatch(ApiProductDescriptionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>956401a96187360ddc917b34e08bcc65</Hash>
</Codenesium>*/