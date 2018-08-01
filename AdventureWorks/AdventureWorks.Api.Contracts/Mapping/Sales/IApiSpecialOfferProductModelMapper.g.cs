using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSpecialOfferProductModelMapper
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
    <Hash>6269d2969b91abdb32968513542bc9ea</Hash>
</Codenesium>*/