using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductPhotoModelMapper
	{
		ApiProductPhotoResponseModel MapRequestToResponse(
			int productPhotoID,
			ApiProductPhotoRequestModel request);

		ApiProductPhotoRequestModel MapResponseToRequest(
			ApiProductPhotoResponseModel response);

		JsonPatchDocument<ApiProductPhotoRequestModel> CreatePatch(ApiProductPhotoRequestModel model);
	}
}

/*<Codenesium>
    <Hash>43e4fcfa98d783bb5eece933b7c55637</Hash>
</Codenesium>*/