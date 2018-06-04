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
			List<BOSalesTaxRate> bos);
	}
}

/*<Codenesium>
    <Hash>5b459cdb775bb7e1f3bbfb1acb076c88</Hash>
</Codenesium>*/