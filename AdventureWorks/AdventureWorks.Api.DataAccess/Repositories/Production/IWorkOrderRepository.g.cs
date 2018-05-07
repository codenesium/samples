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

		POCOWorkOrder Get(int workOrderID);

		List<POCOWorkOrder> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dec7713ee6505f8ddbc4e1692c2b9d42</Hash>
</Codenesium>*/