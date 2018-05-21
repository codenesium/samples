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

		Task<POCOSalesOrderHeaderSalesReason> Get(int salesOrderID);

		Task<List<POCOSalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3622816f37d16f5e06a9ca33edacc861</Hash>
</Codenesium>*/