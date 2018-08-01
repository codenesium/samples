using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductDescriptionModelMapper
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
    <Hash>5e01f9e7a35c5c4fd809219a7fdde1c9</Hash>
</Codenesium>*/