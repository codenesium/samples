using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesTerritoryMapper
	{
		SalesTerritory MapBOToEF(
			BOSalesTerritory bo);

		BOSalesTerritory MapEFToBO(
			SalesTerritory efSalesTerritory);

		List<BOSalesTerritory> MapEFToBO(
			List<SalesTerritory> records);
	}
}

/*<Codenesium>
    <Hash>394b44299ab7d889e8d15d904c22b999</Hash>
</Codenesium>*/