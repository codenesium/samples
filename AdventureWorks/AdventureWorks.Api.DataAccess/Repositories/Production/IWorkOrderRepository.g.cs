using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRepository
	{
		Task<POCOWorkOrder> Create(ApiWorkOrderModel model);

		Task Update(int workOrderID,
		            ApiWorkOrderModel model);

		Task Delete(int workOrderID);

		Task<POCOWorkOrder> Get(int workOrderID);

		Task<List<POCOWorkOrder>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOWorkOrder>> GetProductID(int productID);
		Task<List<POCOWorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>fa8e8a9c0a5ba39b784b3b1ed423bad2</Hash>
</Codenesium>*/