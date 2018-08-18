using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSpecialOfferProductModelMapper
	{
		ApiSpecialOfferProductResponseModel MapRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel request);

		ApiSpecialOfferProductRequestModel MapResponseToRequest(
			ApiSpecialOfferProductResponseModel response);

		JsonPatchDocument<ApiSpecialOfferProductRequestModel> CreatePatch(ApiSpecialOfferProductRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a3f03906ef9c6b6037895f86bf2f48c7</Hash>
</Codenesium>*/