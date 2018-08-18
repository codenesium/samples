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
    <Hash>adfd8724101bed347d768afc280459b3</Hash>
</Codenesium>*/