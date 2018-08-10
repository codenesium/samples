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
    <Hash>67d8deb1b52d932933e42ecddf1bb39c</Hash>
</Codenesium>*/