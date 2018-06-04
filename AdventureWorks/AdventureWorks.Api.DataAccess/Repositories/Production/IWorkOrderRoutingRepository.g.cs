using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		Task<WorkOrderRouting> Create(WorkOrderRouting item);

		Task Update(WorkOrderRouting item);

		Task Delete(int workOrderID);

		Task<WorkOrderRouting> Get(int workOrderID);

		Task<List<WorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<WorkOrderRouting>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>2da0a7163bf345f20a9023ae5825a722</Hash>
</Codenesium>*/