using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesOrderHeaderSalesReasonMapper
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
    <Hash>1e75fadcdfa994859bb8f50188b1b737</Hash>
</Codenesium>*/