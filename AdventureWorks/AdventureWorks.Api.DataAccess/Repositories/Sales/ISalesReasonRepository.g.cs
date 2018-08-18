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
    <Hash>fd0da7b7b224e381b48fcc3405f2e6bd</Hash>
</Codenesium>*/