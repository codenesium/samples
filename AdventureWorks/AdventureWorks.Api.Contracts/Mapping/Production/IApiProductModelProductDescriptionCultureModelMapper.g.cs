using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductModelProductDescriptionCultureModelMapper
	{
		ApiProductModelProductDescriptionCultureResponseModel MapRequestToResponse(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel request);

		ApiProductModelProductDescriptionCultureRequestModel MapResponseToRequest(
			ApiProductModelProductDescriptionCultureResponseModel response);

		JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel> CreatePatch(ApiProductModelProductDescriptionCultureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>df42a8828097b46e450a7d1941e2a3fa</Hash>
</Codenesium>*/