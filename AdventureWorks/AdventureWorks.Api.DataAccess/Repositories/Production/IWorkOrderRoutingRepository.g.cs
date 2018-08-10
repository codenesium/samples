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

		Task<List<WorkOrderRouting>> ByProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>5a8fb4b64ac4f17c109a8b8d2bfc1a0b</Hash>
</Codenesium>*/