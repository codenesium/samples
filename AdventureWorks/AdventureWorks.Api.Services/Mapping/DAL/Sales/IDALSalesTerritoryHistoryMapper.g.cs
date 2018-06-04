using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>a705dd180ff14432f3c91b4c177a1304</Hash>
</Codenesium>*/