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
    <Hash>ad3bf29dfc56bbd6d45c0e14c7c64523</Hash>
</Codenesium>*/