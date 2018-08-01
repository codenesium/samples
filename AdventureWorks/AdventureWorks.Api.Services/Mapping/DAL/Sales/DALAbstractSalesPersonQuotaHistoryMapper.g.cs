using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesPersonQuotaHistoryMapper
	{
		public virtual SalesPersonQuotaHistory MapBOToEF(
			BOSalesPersonQuotaHistory bo)
		{
			SalesPersonQuotaHistory efSalesPersonQuotaHistory = new SalesPersonQuotaHistory();
			efSalesPersonQuotaHistory.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.QuotaDate,
				bo.Rowguid,
				bo.SalesQuota);
			return efSalesPersonQuotaHistory;
		}

		public virtual BOSalesPersonQuotaHistory MapEFToBO(
			SalesPersonQuotaHistory ef)
		{
			var bo = new BOSalesPersonQuotaHistory();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.QuotaDate,
				ef.Rowguid,
				ef.SalesQuota);
			return bo;
		}

		public virtual List<BOSalesPersonQuotaHistory> MapEFToBO(
			List<SalesPersonQuotaHistory> records)
		{
			List<BOSalesPersonQuotaHistory> response = new List<BOSalesPersonQuotaHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>595c853fd9ba3addf040426944989656</Hash>
</Codenesium>*/