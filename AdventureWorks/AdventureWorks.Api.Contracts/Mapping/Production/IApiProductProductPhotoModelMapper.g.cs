using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductProductPhotoModelMapper
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
    <Hash>be564cded499098890ff2e2eb2e7cc52</Hash>
</Codenesium>*/