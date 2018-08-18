using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSpecialOfferModelMapper
	{
		ApiSpecialOfferResponseModel MapRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferRequestModel request);

		ApiSpecialOfferRequestModel MapResponseToRequest(
			ApiSpecialOfferResponseModel response);

		JsonPatchDocument<ApiSpecialOfferRequestModel> CreatePatch(ApiSpecialOfferRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9c5b9963f85375ba8def2d9ef9ffcc3a</Hash>
</Codenesium>*/