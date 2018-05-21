using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOWorkOrderRouting
	{
		Task<CreateResponse<POCOWorkOrderRouting>> Create(
			ApiWorkOrderRoutingModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            ApiWorkOrderRoutingModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<POCOWorkOrderRouting> Get(int workOrderID);

		Task<List<POCOWorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOWorkOrderRouting>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>8580fc621ac80d24227605edb4d38d16</Hash>
</Codenesium>*/