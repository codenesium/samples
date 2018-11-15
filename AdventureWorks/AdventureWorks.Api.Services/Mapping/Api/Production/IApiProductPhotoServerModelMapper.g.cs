using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductPhotoServerModelMapper
	{
		ApiProductPhotoServerResponseModel MapServerRequestToResponse(
			int productPhotoID,
			ApiProductPhotoServerRequestModel request);

		ApiProductPhotoServerRequestModel MapServerResponseToRequest(
			ApiProductPhotoServerResponseModel response);

		ApiProductPhotoClientRequestModel MapServerResponseToClientRequest(
			ApiProductPhotoServerResponseModel response);

		JsonPatchDocument<ApiProductPhotoServerRequestModel> CreatePatch(ApiProductPhotoServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2ecb6948352fe01bc5b237dd4b9ebd2d</Hash>
</Codenesium>*/