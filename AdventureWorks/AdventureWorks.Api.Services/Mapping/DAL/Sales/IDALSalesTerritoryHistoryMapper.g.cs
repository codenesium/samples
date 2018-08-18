using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTerritoryHistoryMapper
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
    <Hash>2e99181ab42f8d4d599f21e8c54bcf7c</Hash>
</Codenesium>*/