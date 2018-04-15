using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRepository
	{
		int Create(WorkOrderModel model);

		void Update(int workOrderID,
		            WorkOrderModel model);

		void Delete(int workOrderID);

		ApiResponse GetById(int workOrderID);

		POCOWorkOrder GetByIdDirect(int workOrderID);

		ApiResponse GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fde467961917930e7b148a16af928998</Hash>
</Codenesium>*/