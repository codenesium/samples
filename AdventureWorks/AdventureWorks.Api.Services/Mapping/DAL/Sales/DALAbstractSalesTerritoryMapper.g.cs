using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesTerritoryMapper
	{
		public virtual SalesTerritory MapBOToEF(
			BOSalesTerritory bo)
		{
			SalesTerritory efSalesTerritory = new SalesTerritory();
			efSalesTerritory.SetProperties(
				bo.@Group,
				bo.CostLastYear,
				bo.CostYTD,
				bo.CountryRegionCode,
				bo.ModifiedDate,
				bo.Name,
				bo.Rowguid,
				bo.SalesLastYear,
				bo.SalesYTD,
				bo.TerritoryID);
			return efSalesTerritory;
		}

		public virtual BOSalesTerritory MapEFToBO(
			SalesTerritory ef)
		{
			var bo = new BOSalesTerritory();

			bo.SetProperties(
				ef.TerritoryID,
				ef.@Group,
				ef.CostLastYear,
				ef.CostYTD,
				ef.CountryRegionCode,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.SalesLastYear,
				ef.SalesYTD);
			return bo;
		}

		public virtual List<BOSalesTerritory> MapEFToBO(
			List<SalesTerritory> records)
		{
			List<BOSalesTerritory> response = new List<BOSalesTerritory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d5e7c6a2e3609356f97ec617416df3a5</Hash>
</Codenesium>*/