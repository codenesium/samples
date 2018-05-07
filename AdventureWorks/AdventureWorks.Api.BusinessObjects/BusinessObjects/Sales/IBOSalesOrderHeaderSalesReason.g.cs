using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderHeaderSalesReason
	{
		Task<CreateResponse<int>> Create(
			SalesOrderHeaderSalesReasonModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            SalesOrderHeaderSalesReasonModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		POCOSalesOrderHeaderSalesReason Get(int salesOrderID);

		List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2dec41252debce11544773acff6a1299</Hash>
</Codenesium>*/