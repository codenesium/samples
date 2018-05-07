using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOWorkOrder
	{
		Task<CreateResponse<int>> Create(
			WorkOrderModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            WorkOrderModel model);

		Task<ActionResponse> Delete(int workOrderID);

		POCOWorkOrder Get(int workOrderID);

		List<POCOWorkOrder> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e82e51e5fccd4bae28c764df23b5c609</Hash>
</Codenesium>*/