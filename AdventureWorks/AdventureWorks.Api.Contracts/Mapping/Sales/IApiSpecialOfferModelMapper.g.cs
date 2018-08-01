using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSpecialOfferModelMapper
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
    <Hash>7343795ad05fb5290dd79cde2b883f90</Hash>
</Codenesium>*/