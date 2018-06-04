using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesOrderDetailMapper
	{
		SalesOrderDetail MapBOToEF(
			BOSalesOrderDetail bo);

		BOSalesOrderDetail MapEFToBO(
			SalesOrderDetail efSalesOrderDetail);

		List<BOSalesOrderDetail> MapEFToBO(
			List<SalesOrderDetail> records);
	}
}

/*<Codenesium>
    <Hash>2de41d3719905a35bfdb6b3a001b4f9f</Hash>
</Codenesium>*/