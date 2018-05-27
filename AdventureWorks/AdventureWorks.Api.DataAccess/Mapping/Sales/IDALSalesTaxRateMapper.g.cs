using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesTaxRateMapper
	{
		void MapDTOToEF(
			int salesTaxRateID,
			DTOSalesTaxRate dto,
			SalesTaxRate efSalesTaxRate);

		DTOSalesTaxRate MapEFToDTO(
			SalesTaxRate efSalesTaxRate);
	}
}

/*<Codenesium>
    <Hash>16114a2e539c4c74285e2f4075ddb934</Hash>
</Codenesium>*/