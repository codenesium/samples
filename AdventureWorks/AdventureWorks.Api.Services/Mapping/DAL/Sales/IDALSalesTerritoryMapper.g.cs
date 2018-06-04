using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>cb9ac80d8933d09a82077c1bc72e8a40</Hash>
</Codenesium>*/