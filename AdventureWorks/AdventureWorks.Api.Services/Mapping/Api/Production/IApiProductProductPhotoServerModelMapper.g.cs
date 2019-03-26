using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductProductPhotoServerModelMapper
	{
		ApiProductProductPhotoServerResponseModel MapServerRequestToResponse(
			int productID,
			ApiProductProductPhotoServerRequestModel request);

		ApiProductProductPhotoServerRequestModel MapServerResponseToRequest(
			ApiProductProductPhotoServerResponseModel response);

		ApiProductProductPhotoClientRequestModel MapServerResponseToClientRequest(
			ApiProductProductPhotoServerResponseModel response);

		JsonPatchDocument<ApiProductProductPhotoServerRequestModel> CreatePatch(ApiProductProductPhotoServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>933d9b0c0ed212254036f44b757b682d</Hash>
</Codenesium>*/