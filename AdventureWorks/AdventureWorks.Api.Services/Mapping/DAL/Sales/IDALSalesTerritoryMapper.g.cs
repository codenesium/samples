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
    <Hash>732640eb701927151ef8b54705e8a047</Hash>
</Codenesium>*/