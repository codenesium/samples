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
    <Hash>bb1efcef3a148a5ece42e766a5392022</Hash>
</Codenesium>*/