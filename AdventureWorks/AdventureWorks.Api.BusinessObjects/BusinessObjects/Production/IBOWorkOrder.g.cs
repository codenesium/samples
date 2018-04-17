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

		ApiResponse GetById(int workOrderID);

		POCOWorkOrder GetByIdDirect(int workOrderID);

		ApiResponse GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>97a65214d9ff62eb16eb8a6cb68db5e0</Hash>
</Codenesium>*/