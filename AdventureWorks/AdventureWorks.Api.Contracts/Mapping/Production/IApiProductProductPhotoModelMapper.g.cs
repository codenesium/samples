using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductProductPhotoModelMapper
	{
		ApiProductProductPhotoResponseModel MapRequestToResponse(
			int productID,
			ApiProductProductPhotoRequestModel request);

		ApiProductProductPhotoRequestModel MapResponseToRequest(
			ApiProductProductPhotoResponseModel response);

		JsonPatchDocument<ApiProductProductPhotoRequestModel> CreatePatch(ApiProductProductPhotoRequestModel model);
	}
}

/*<Codenesium>
    <Hash>09a250550ee52855df2a5c0f80fd0f7f</Hash>
</Codenesium>*/