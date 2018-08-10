using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IWorkOrderRepository
	{
		Task<WorkOrder> Create(WorkOrder item);

		Task Update(WorkOrder item);

		Task Delete(int workOrderID);

		Task<WorkOrder> Get(int workOrderID);

		Task<List<WorkOrder>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrder>> ByProductID(int productID);

		Task<List<WorkOrder>> ByScrapReasonID(short? scrapReasonID);

		Task<List<WorkOrderRouting>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>00cc60cc9a3487f08e5cc36d47269c67</Hash>
</Codenesium>*/