using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesPersonQuotaHistoryMapper
	{
		public virtual SalesPersonQuotaHistory MapBOToEF(
			BOSalesPersonQuotaHistory bo)
		{
			SalesPersonQuotaHistory efSalesPersonQuotaHistory = new SalesPersonQuotaHistory ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>f305bc98a2ee7d602f83322fcaf5e112</Hash>
</Codenesium>*/