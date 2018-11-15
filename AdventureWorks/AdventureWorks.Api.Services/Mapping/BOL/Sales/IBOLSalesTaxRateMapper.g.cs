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
			ApiSalesTaxRateServerRequestModel model);

		ApiSalesTaxRateServerResponseModel MapBOToModel(
			BOSalesTaxRate boSalesTaxRate);

		List<ApiSalesTaxRateServerResponseModel> MapBOToModel(
			List<BOSalesTaxRate> items);
	}
}

/*<Codenesium>
    <Hash>3a44682daf501166d8f31ff131d78349</Hash>
</Codenesium>*/