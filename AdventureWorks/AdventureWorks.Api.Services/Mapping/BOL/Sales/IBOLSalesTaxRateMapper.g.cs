using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesTaxRateMapper
	{
		BOSalesTaxRate MapModelToBO(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel model);

		ApiSalesTaxRateResponseModel MapBOToModel(
			BOSalesTaxRate boSalesTaxRate);

		List<ApiSalesTaxRateResponseModel> MapBOToModel(
			List<BOSalesTaxRate> items);
	}
}

/*<Codenesium>
    <Hash>4dd9d669bce737bd59e2ec1716af7663</Hash>
</Codenesium>*/