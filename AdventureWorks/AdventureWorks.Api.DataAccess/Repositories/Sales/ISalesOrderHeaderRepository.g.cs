using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		int Create(SalesOrderHeaderModel model);

		void Update(int salesOrderID,
		            SalesOrderHeaderModel model);

		void Delete(int salesOrderID);

		POCOSalesOrderHeader Get(int salesOrderID);

		List<POCOSalesOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>32c0e10887fe34ac194cc18db6309729</Hash>
</Codenesium>*/