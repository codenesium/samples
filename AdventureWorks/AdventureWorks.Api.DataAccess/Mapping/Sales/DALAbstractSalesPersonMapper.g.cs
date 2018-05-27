using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesPersonMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOSalesPerson dto,
			SalesPerson efSalesPerson)
		{
			efSalesPerson.SetProperties(
				businessEntityID,
				dto.Bonus,
				dto.CommissionPct,
				dto.ModifiedDate,
				dto.Rowguid,
				dto.SalesLastYear,
				dto.SalesQuota,
				dto.SalesYTD,
				dto.TerritoryID);
		}

		public virtual DTOSalesPerson MapEFToDTO(
			SalesPerson ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesPerson();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.Bonus,
				ef.CommissionPct,
				ef.ModifiedDate,
				ef.Rowguid,
				ef.SalesLastYear,
				ef.SalesQuota,
				ef.SalesYTD,
				ef.TerritoryID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>abe57461058bb22cd04517f41e3b79a9</Hash>
</Codenesium>*/