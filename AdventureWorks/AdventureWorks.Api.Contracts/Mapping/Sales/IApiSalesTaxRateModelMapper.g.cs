using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesTaxRateModelMapper
	{
		ApiSalesTaxRateResponseModel MapRequestToResponse(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel request);

		ApiSalesTaxRateRequestModel MapResponseToRequest(
			ApiSalesTaxRateResponseModel response);

		JsonPatchDocument<ApiSalesTaxRateRequestModel> CreatePatch(ApiSalesTaxRateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>07ba4f605257ef07b16029c456129164</Hash>
</Codenesium>*/