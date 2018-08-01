using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesTerritoryMapper
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
    <Hash>c82a4426a68134879171f08de549a321</Hash>
</Codenesium>*/