using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAWBuildVersionServerModelMapper
	{
		ApiAWBuildVersionServerResponseModel MapServerRequestToResponse(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel request);

		ApiAWBuildVersionServerRequestModel MapServerResponseToRequest(
			ApiAWBuildVersionServerResponseModel response);

		ApiAWBuildVersionClientRequestModel MapServerResponseToClientRequest(
			ApiAWBuildVersionServerResponseModel response);

		JsonPatchDocument<ApiAWBuildVersionServerRequestModel> CreatePatch(ApiAWBuildVersionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5044bd30c0983bd00b612207e536bbf2</Hash>
</Codenesium>*/