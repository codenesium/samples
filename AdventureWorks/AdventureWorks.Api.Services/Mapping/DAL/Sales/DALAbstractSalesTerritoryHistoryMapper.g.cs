using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesTerritoryHistoryMapper
	{
		public virtual SalesTerritoryHistory MapBOToEF(
			BOSalesTerritoryHistory bo)
		{
			SalesTerritoryHistory efSalesTerritoryHistory = new SalesTerritoryHistory();
			efSalesTerritoryHistory.SetProperties(
				bo.BusinessEntityID,
				bo.EndDate,
				bo.ModifiedDate,
				bo.Rowguid,
				bo.StartDate,
				bo.TerritoryID);
			return efSalesTerritoryHistory;
		}

		public virtual BOSalesTerritoryHistory MapEFToBO(
			SalesTerritoryHistory ef)
		{
			var bo = new BOSalesTerritoryHistory();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.EndDate,
				ef.ModifiedDate,
				ef.Rowguid,
				ef.StartDate,
				ef.TerritoryID);
			return bo;
		}

		public virtual List<BOSalesTerritoryHistory> MapEFToBO(
			List<SalesTerritoryHistory> records)
		{
			List<BOSalesTerritoryHistory> response = new List<BOSalesTerritoryHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a107cc0614e2f7183d5be14d32913575</Hash>
</Codenesium>*/