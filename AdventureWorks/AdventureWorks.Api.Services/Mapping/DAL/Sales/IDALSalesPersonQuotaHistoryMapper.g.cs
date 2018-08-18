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
    <Hash>1a62f79fbfc50d0bf69a9ed9acc41d0a</Hash>
</Codenesium>*/