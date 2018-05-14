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
		Task<CreateResponse<POCOSalesOrderHeaderSalesReason>> Create(
			ApiSalesOrderHeaderSalesReasonModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            ApiSalesOrderHeaderSalesReasonModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		POCOSalesOrderHeaderSalesReason Get(int salesOrderID);

		List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>35bbc64b58447ffd0dca3442d5669137</Hash>
</Codenesium>*/