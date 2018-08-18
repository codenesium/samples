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
    <Hash>4ecb0ef5a71d5870c5b8fa012c7c67e4</Hash>
</Codenesium>*/