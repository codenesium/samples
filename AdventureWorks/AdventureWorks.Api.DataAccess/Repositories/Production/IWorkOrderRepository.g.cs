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

		Task<List<WorkOrder>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrder>> ByScrapReasonID(short? scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4aa22c2f73b6c0b3d5e09c5157effc5b</Hash>
</Codenesium>*/