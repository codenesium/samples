using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductModelProductDescriptionCultureModelMapper
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
    <Hash>c31621468697dbca3dc26be0b8c110ba</Hash>
</Codenesium>*/