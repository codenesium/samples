using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSpecialOfferServerModelMapper
	{
		ApiSpecialOfferServerResponseModel MapServerRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel request);

		ApiSpecialOfferServerRequestModel MapServerResponseToRequest(
			ApiSpecialOfferServerResponseModel response);

		ApiSpecialOfferClientRequestModel MapServerResponseToClientRequest(
			ApiSpecialOfferServerResponseModel response);

		JsonPatchDocument<ApiSpecialOfferServerRequestModel> CreatePatch(ApiSpecialOfferServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e813b9d50fc3f82bfd750900086854c8</Hash>
</Codenesium>*/