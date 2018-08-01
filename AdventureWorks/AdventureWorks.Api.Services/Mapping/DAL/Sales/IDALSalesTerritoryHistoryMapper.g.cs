using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesTerritoryHistoryMapper
	{
		SalesTerritoryHistory MapBOToEF(
			BOSalesTerritoryHistory bo);

		BOSalesTerritoryHistory MapEFToBO(
			SalesTerritoryHistory efSalesTerritoryHistory);

		List<BOSalesTerritoryHistory> MapEFToBO(
			List<SalesTerritoryHistory> records);
	}
}

/*<Codenesium>
    <Hash>88af72eb68c408885fadd51b2657040f</Hash>
</Codenesium>*/