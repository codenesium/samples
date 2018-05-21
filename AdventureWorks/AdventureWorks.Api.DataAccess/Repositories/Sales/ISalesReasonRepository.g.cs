using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		Task<POCOSalesReason> Create(ApiSalesReasonModel model);

		Task Update(int salesReasonID,
		            ApiSalesReasonModel model);

		Task Delete(int salesReasonID);

		Task<POCOSalesReason> Get(int salesReasonID);

		Task<List<POCOSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a6d542bef848fd2242fdd957eebd18c0</Hash>
</Codenesium>*/