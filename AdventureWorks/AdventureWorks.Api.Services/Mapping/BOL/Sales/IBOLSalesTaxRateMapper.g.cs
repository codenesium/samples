using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesTaxRateMapper
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
    <Hash>d90b853bd70c8a293fec6f6a46583f2f</Hash>
</Codenesium>*/