using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesOrderDetailMapper
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
    <Hash>377879b0c1e3dc6fa30f70c9d3a6f7e5</Hash>
</Codenesium>*/