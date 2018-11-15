using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesPersonMapper
	{
		public virtual SalesPerson MapBOToEF(
			BOSalesPerson bo)
		{
			SalesPerson efSalesPerson = new SalesPerson();
			efSalesPerson.SetProperties(
				bo.Bonus,
				bo.BusinessEntityID,
				bo.CommissionPct,
				bo.ModifiedDate,
				bo.Rowguid,
				bo.SalesLastYear,
				bo.SalesQuota,
				bo.SalesYTD,
				bo.TerritoryID);
			return efSalesPerson;
		}

		public virtual BOSalesPerson MapEFToBO(
			SalesPerson ef)
		{
			var bo = new BOSalesPerson();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.Bonus,
				ef.CommissionPct,
				ef.ModifiedDate,
				ef.Rowguid,
				ef.SalesLastYear,
				ef.SalesQuota,
				ef.SalesYTD,
				ef.TerritoryID);
			return bo;
		}

		public virtual List<BOSalesPerson> MapEFToBO(
			List<SalesPerson> records)
		{
			List<BOSalesPerson> response = new List<BOSalesPerson>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ec4f7fc60edb39605880795faa7a45a0</Hash>
</Codenesium>*/