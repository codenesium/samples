using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductPhotoModelMapper
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
    <Hash>b553f0738d1b1027a4383706469a91e8</Hash>
</Codenesium>*/