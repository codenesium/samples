using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>a1abcc4e0e6641fb7b48000938d9345a</Hash>
</Codenesium>*/