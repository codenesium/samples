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

		ApiResponse GetById(int workOrderID);

		POCOWorkOrderRouting GetByIdDirect(int workOrderID);

		ApiResponse GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrderRouting> GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>df7b1d312d0dcb7e1d3704add7bdd480</Hash>
</Codenesium>*/