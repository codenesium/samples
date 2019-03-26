using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTaxRateMapper
	{
		SalesTaxRate MapModelToEntity(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel model);

		ApiSalesTaxRateServerResponseModel MapEntityToModel(
			SalesTaxRate item);

		List<ApiSalesTaxRateServerResponseModel> MapEntityToModel(
			List<SalesTaxRate> items);
	}
}

/*<Codenesium>
    <Hash>f6d09dfe22b20ec2ba1a013e8d8a7757</Hash>
</Codenesium>*/