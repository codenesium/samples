using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesOrderHeaderMapper
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
    <Hash>ab93887d16710f2c897bd35ea08466fb</Hash>
</Codenesium>*/