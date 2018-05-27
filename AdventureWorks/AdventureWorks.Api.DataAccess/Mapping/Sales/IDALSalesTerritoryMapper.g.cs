using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesTerritoryMapper
	{
		void MapDTOToEF(
			int territoryID,
			DTOSalesTerritory dto,
			SalesTerritory efSalesTerritory);

		DTOSalesTerritory MapEFToDTO(
			SalesTerritory efSalesTerritory);
	}
}

/*<Codenesium>
    <Hash>9f07370f1e495f3c26f557c9af4079a8</Hash>
</Codenesium>*/