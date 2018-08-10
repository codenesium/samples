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
    <Hash>579326a61b5ec82f426591f7e20635a5</Hash>
</Codenesium>*/