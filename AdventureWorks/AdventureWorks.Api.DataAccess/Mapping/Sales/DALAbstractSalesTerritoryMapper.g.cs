using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesTerritoryMapper
	{
		public virtual void MapDTOToEF(
			int territoryID,
			DTOSalesTerritory dto,
			SalesTerritory efSalesTerritory)
		{
			efSalesTerritory.SetProperties(
				territoryID,
				dto.CostLastYear,
				dto.CostYTD,
				dto.CountryRegionCode,
				dto.@Group,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid,
				dto.SalesLastYear,
				dto.SalesYTD);
		}

		public virtual DTOSalesTerritory MapEFToDTO(
			SalesTerritory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesTerritory();

			dto.SetProperties(
				ef.TerritoryID,
				ef.CostLastYear,
				ef.CostYTD,
				ef.CountryRegionCode,
				ef.@Group,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.SalesLastYear,
				ef.SalesYTD);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>75b621264268c24c8cc331d7be714ade</Hash>
</Codenesium>*/