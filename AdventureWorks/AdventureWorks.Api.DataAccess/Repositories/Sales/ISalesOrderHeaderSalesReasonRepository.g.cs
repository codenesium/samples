using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		int Create(SalesOrderHeaderSalesReasonModel model);

		void Update(int salesOrderID,
		            SalesOrderHeaderSalesReasonModel model);

		void Delete(int salesOrderID);

		POCOSalesOrderHeaderSalesReason Get(int salesOrderID);

		List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1d4ba4b360036da1c02f1c98f042f9a0</Hash>
</Codenesium>*/