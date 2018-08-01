using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>c84212c648311017741cbdeb3b2bd91c</Hash>
</Codenesium>*/