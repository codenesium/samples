using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesOrderHeaderSalesReasonRepository
	{
		Task<SalesOrderHeaderSalesReason> Create(SalesOrderHeaderSalesReason item);

		Task Update(SalesOrderHeaderSalesReason item);

		Task Delete(int salesOrderID);

		Task<SalesOrderHeaderSalesReason> Get(int salesOrderID);

		Task<List<SalesOrderHeaderSalesReason>> All(int limit = int.MaxValue, int offset = 0);

		Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID);

		Task<SalesReason> GetSalesReason(int salesReasonID);
	}
}

/*<Codenesium>
    <Hash>9043fe8e2edf95016e0eb064543584f2</Hash>
</Codenesium>*/