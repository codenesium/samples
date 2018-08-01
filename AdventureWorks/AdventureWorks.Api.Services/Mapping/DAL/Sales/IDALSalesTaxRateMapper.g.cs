using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>535998ed4241c1580cba0aaea76181f0</Hash>
</Codenesium>*/