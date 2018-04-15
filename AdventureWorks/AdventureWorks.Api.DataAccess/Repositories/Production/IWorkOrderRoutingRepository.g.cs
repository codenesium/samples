using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		int Create(WorkOrderRoutingModel model);

		void Update(int workOrderID,
		            WorkOrderRoutingModel model);

		void Delete(int workOrderID);

		ApiResponse GetById(int workOrderID);

		POCOWorkOrderRouting GetByIdDirect(int workOrderID);

		ApiResponse GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrderRouting> GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fcd8c08efd942d21dfc98a67697afcaa</Hash>
</Codenesium>*/