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
    <Hash>90676c6ae6712add23754332b8e824ef</Hash>
</Codenesium>*/