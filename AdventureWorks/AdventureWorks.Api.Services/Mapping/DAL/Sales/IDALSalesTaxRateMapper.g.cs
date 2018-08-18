using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTaxRateMapper
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
    <Hash>541259c677aac38d0c7ababa2c364a25</Hash>
</Codenesium>*/