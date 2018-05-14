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

		POCOWorkOrderRouting Get(int workOrderID);

		List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrderRouting> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>1d3196eb013b82b002d1de5df48c190a</Hash>
</Codenesium>*/