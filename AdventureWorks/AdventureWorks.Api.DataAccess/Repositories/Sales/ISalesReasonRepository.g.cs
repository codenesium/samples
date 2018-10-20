using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesReasonRepository
	{
		Task<SalesReason> Create(SalesReason item);

		Task Update(SalesReason item);

		Task Delete(int salesReasonID);

		Task<SalesReason> Get(int salesReasonID);

		Task<List<SalesReason>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SalesReason>> BySalesOrderID(int salesOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7e5ed644050576b97432912878ab738c</Hash>
</Codenesium>*/