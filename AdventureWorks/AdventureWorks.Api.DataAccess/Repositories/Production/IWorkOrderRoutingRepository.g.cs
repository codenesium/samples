using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IWorkOrderRoutingRepository
	{
		Task<WorkOrderRouting> Create(WorkOrderRouting item);

		Task Update(WorkOrderRouting item);

		Task Delete(int workOrderID);

		Task<WorkOrderRouting> Get(int workOrderID);

		Task<List<WorkOrderRouting>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrderRouting>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3793399846e4efba4d35392a4e84a0f9</Hash>
</Codenesium>*/