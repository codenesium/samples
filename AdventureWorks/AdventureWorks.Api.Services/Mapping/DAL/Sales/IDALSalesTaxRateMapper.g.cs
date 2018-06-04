using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesTaxRateMapper
	{
		SalesTaxRate MapBOToEF(
			BOSalesTaxRate bo);

		BOSalesTaxRate MapEFToBO(
			SalesTaxRate efSalesTaxRate);

		List<BOSalesTaxRate> MapEFToBO(
			List<SalesTaxRate> records);
	}
}

/*<Codenesium>
    <Hash>5f699067bd8413916e90921cf7d75320</Hash>
</Codenesium>*/