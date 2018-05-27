using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesTaxRateMapper
	{
		DTOSalesTaxRate MapModelToDTO(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel model);

		ApiSalesTaxRateResponseModel MapDTOToModel(
			DTOSalesTaxRate dtoSalesTaxRate);

		List<ApiSalesTaxRateResponseModel> MapDTOToModel(
			List<DTOSalesTaxRate> dtos);
	}
}

/*<Codenesium>
    <Hash>92c4308cd01444009958e69791b06494</Hash>
</Codenesium>*/