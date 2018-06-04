using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesPersonQuotaHistoryMapper
	{
		SalesPersonQuotaHistory MapBOToEF(
			BOSalesPersonQuotaHistory bo);

		BOSalesPersonQuotaHistory MapEFToBO(
			SalesPersonQuotaHistory efSalesPersonQuotaHistory);

		List<BOSalesPersonQuotaHistory> MapEFToBO(
			List<SalesPersonQuotaHistory> records);
	}
}

/*<Codenesium>
    <Hash>ebb0e1738f427858cc47db9462d5aa3a</Hash>
</Codenesium>*/