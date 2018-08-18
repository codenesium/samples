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
    <Hash>bb33d01afa5c778d66c637a68cc83b72</Hash>
</Codenesium>*/