using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiIllustrationServerModelMapper
	{
		ApiIllustrationServerResponseModel MapServerRequestToResponse(
			int illustrationID,
			ApiIllustrationServerRequestModel request);

		ApiIllustrationServerRequestModel MapServerResponseToRequest(
			ApiIllustrationServerResponseModel response);

		ApiIllustrationClientRequestModel MapServerResponseToClientRequest(
			ApiIllustrationServerResponseModel response);

		JsonPatchDocument<ApiIllustrationServerRequestModel> CreatePatch(ApiIllustrationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>87b01374ab842cdfad385bdb3afca95c</Hash>
</Codenesium>*/