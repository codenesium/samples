using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOWorkOrder
	{
		Task<CreateResponse<POCOWorkOrder>> Create(
			ApiWorkOrderModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            ApiWorkOrderModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<POCOWorkOrder> Get(int workOrderID);

		Task<List<POCOWorkOrder>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOWorkOrder>> GetProductID(int productID);
		Task<List<POCOWorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>1d9d4a9219270fbb5fc46e40703abb59</Hash>
</Codenesium>*/