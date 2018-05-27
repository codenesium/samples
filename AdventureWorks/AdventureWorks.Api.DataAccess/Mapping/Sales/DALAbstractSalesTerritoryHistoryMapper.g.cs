using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesTerritoryHistoryMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOSalesTerritoryHistory dto,
			SalesTerritoryHistory efSalesTerritoryHistory)
		{
			efSalesTerritoryHistory.SetProperties(
				businessEntityID,
				dto.EndDate,
				dto.ModifiedDate,
				dto.Rowguid,
				dto.StartDate,
				dto.TerritoryID);
		}

		public virtual DTOSalesTerritoryHistory MapEFToDTO(
			SalesTerritoryHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesTerritoryHistory();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.EndDate,
				ef.ModifiedDate,
				ef.Rowguid,
				ef.StartDate,
				ef.TerritoryID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>21c931acb81195f86b2575b832d017e5</Hash>
</Codenesium>*/