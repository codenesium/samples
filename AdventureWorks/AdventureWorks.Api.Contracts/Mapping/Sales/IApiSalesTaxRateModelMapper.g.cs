using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesTaxRateModelMapper
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
    <Hash>9287415686a1d16995561bec81bbe15e</Hash>
</Codenesium>*/