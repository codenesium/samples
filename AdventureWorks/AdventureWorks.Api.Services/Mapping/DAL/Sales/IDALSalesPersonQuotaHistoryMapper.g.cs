using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesPersonQuotaHistoryMapper
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
    <Hash>acecdf0a57963aa154f34dbb62bd51e7</Hash>
</Codenesium>*/