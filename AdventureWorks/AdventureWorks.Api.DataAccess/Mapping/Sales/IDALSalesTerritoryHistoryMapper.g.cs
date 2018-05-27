using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSalesTerritoryHistoryMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOSalesTerritoryHistory dto,
			SalesTerritoryHistory efSalesTerritoryHistory);

		DTOSalesTerritoryHistory MapEFToDTO(
			SalesTerritoryHistory efSalesTerritoryHistory);
	}
}

/*<Codenesium>
    <Hash>9fa1d328a56f603e276ee6d6d0036387</Hash>
</Codenesium>*/