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

		POCOWorkOrder Get(int workOrderID);

		List<POCOWorkOrder> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrder> GetProductID(int productID);
		List<POCOWorkOrder> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>5a3aa6ed85ee24eb13c7437dbfce6058</Hash>
</Codenesium>*/