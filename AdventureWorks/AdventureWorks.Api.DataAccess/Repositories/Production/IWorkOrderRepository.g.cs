using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRepository
	{
		POCOWorkOrder Create(ApiWorkOrderModel model);

		void Update(int workOrderID,
		            ApiWorkOrderModel model);

		void Delete(int workOrderID);

		POCOWorkOrder Get(int workOrderID);

		List<POCOWorkOrder> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrder> GetProductID(int productID);
		List<POCOWorkOrder> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>539fd74fd3183bd2130362508c3c328e</Hash>
</Codenesium>*/