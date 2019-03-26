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

		Task<List<WorkOrder>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<WorkOrder>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrder>> ByScrapReasonID(short? scrapReasonID, int limit = int.MaxValue, int offset = 0);

		Task<Product> ProductByProductID(int productID);

		Task<ScrapReason> ScrapReasonByScrapReasonID(short? scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>07b9213da0755a1e902e912e7ff66dcb</Hash>
</Codenesium>*/