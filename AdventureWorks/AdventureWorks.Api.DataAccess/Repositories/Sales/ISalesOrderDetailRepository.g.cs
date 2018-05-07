using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		int Create(SalesOrderDetailModel model);

		void Update(int salesOrderID,
		            SalesOrderDetailModel model);

		void Delete(int salesOrderID);

		POCOSalesOrderDetail Get(int salesOrderID);

		List<POCOSalesOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f627bf3a7edd738abe3bc25a10f22c2d</Hash>
</Codenesium>*/