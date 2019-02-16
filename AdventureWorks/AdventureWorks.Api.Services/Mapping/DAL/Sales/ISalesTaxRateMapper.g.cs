using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTaxRateMapper
	{
		SalesTaxRate MapModelToBO(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel model);

		ApiSalesTaxRateServerResponseModel MapBOToModel(
			SalesTaxRate item);

		List<ApiSalesTaxRateServerResponseModel> MapBOToModel(
			List<SalesTaxRate> items);
	}
}

/*<Codenesium>
    <Hash>0990ff15f37590a96d85e11dd832e35d</Hash>
</Codenesium>*/