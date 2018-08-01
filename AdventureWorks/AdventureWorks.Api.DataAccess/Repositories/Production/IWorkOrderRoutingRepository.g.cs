using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
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
    <Hash>87a133bc7830a95157bcfe66bc1fcc50</Hash>
</Codenesium>*/