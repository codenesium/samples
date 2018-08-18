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
    <Hash>64ff470639f1f59dc58c23c3e044fed9</Hash>
</Codenesium>*/