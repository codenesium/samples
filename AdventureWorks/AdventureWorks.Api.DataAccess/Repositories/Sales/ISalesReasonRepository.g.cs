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

		Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>259737aabea3ba001b3f4e3de3f6e7e9</Hash>
</Codenesium>*/