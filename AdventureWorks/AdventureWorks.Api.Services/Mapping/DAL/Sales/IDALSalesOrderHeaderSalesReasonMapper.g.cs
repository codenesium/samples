using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>d599c8266438d6d8aeffa5682a87f3f4</Hash>
</Codenesium>*/