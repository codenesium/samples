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
		Task<CreateResponse<int>> Create(
			WorkOrderRoutingModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            WorkOrderRoutingModel model);

		Task<ActionResponse> Delete(int workOrderID);

		POCOWorkOrderRouting Get(int workOrderID);

		List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1035d45df0b2b58cc91b2a39eccbc340</Hash>
</Codenesium>*/