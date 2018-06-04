using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>2d4e19ce45eb42e873b28ed91a5e27da</Hash>
</Codenesium>*/