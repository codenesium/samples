using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		Task<SalesOrderHeaderSalesReason> Create(SalesOrderHeaderSalesReason item);

		Task Update(SalesOrderHeaderSalesReason item);

		Task Delete(int salesOrderID);

		Task<SalesOrderHeaderSalesReason> Get(int salesOrderID);

		Task<List<SalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7c38a5a5ce938e85a0915c81e0284340</Hash>
</Codenesium>*/