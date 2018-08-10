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
    <Hash>b46530d59b8721ab2a8c36df42e5f9d5</Hash>
</Codenesium>*/