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
    <Hash>35d3546869e28703eff0d3c81086f513</Hash>
</Codenesium>*/