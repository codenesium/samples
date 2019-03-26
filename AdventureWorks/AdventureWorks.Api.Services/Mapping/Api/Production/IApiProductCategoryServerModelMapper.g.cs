using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductCategoryServerModelMapper
	{
		ApiProductCategoryServerResponseModel MapServerRequestToResponse(
			int productCategoryID,
			ApiProductCategoryServerRequestModel request);

		ApiProductCategoryServerRequestModel MapServerResponseToRequest(
			ApiProductCategoryServerResponseModel response);

		ApiProductCategoryClientRequestModel MapServerResponseToClientRequest(
			ApiProductCategoryServerResponseModel response);

		JsonPatchDocument<ApiProductCategoryServerRequestModel> CreatePatch(ApiProductCategoryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cd6f520fc959b5cec40de45cf2f3ede2</Hash>
</Codenesium>*/