using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		Task<POCOSalesOrderHeaderSalesReason> Create(ApiSalesOrderHeaderSalesReasonModel model);

		Task Update(int salesOrderID,
		            ApiSalesOrderHeaderSalesReasonModel model);

		Task Delete(int salesOrderID);

		Task<POCOSalesOrderHeaderSalesReason> Get(int salesOrderID);

		Task<List<POCOSalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9dba6ac55c756eaf8836656566d2549d</Hash>
</Codenesium>*/