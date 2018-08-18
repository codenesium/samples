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
    <Hash>4828e5fbd7f20c1602f623252ea7394c</Hash>
</Codenesium>*/