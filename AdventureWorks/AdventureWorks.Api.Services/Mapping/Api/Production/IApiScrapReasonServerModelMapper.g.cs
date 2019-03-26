using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiScrapReasonServerModelMapper
	{
		ApiScrapReasonServerResponseModel MapServerRequestToResponse(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel request);

		ApiScrapReasonServerRequestModel MapServerResponseToRequest(
			ApiScrapReasonServerResponseModel response);

		ApiScrapReasonClientRequestModel MapServerResponseToClientRequest(
			ApiScrapReasonServerResponseModel response);

		JsonPatchDocument<ApiScrapReasonServerRequestModel> CreatePatch(ApiScrapReasonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7ee0244809f7e466f13c98b687dc4c60</Hash>
</Codenesium>*/