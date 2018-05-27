using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		Task<DTOSalesOrderHeaderSalesReason> Create(DTOSalesOrderHeaderSalesReason dto);

		Task Update(int salesOrderID,
		            DTOSalesOrderHeaderSalesReason dto);

		Task Delete(int salesOrderID);

		Task<DTOSalesOrderHeaderSalesReason> Get(int salesOrderID);

		Task<List<DTOSalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b919d0e8354fa1d63d97b31e2476de0a</Hash>
</Codenesium>*/