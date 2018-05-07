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

		POCOWorkOrderRouting Get(int workOrderID);

		List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e47885c39e48b02072db21c60019055f</Hash>
</Codenesium>*/