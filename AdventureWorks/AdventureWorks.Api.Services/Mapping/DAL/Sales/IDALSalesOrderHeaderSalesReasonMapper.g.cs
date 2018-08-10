using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesOrderHeaderSalesReasonMapper
	{
		SalesOrderHeaderSalesReason MapBOToEF(
			BOSalesOrderHeaderSalesReason bo);

		BOSalesOrderHeaderSalesReason MapEFToBO(
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

		List<BOSalesOrderHeaderSalesReason> MapEFToBO(
			List<SalesOrderHeaderSalesReason> records);
	}
}

/*<Codenesium>
    <Hash>9b6adef8da252f67534d8af9c43c3b0f</Hash>
</Codenesium>*/