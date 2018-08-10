using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesOrderHeaderMapper
	{
		SalesOrderHeader MapBOToEF(
			BOSalesOrderHeader bo);

		BOSalesOrderHeader MapEFToBO(
			SalesOrderHeader efSalesOrderHeader);

		List<BOSalesOrderHeader> MapEFToBO(
			List<SalesOrderHeader> records);
	}
}

/*<Codenesium>
    <Hash>8903a540336f55743cb7edfe9c323fb0</Hash>
</Codenesium>*/