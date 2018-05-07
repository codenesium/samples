using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		int Create(PurchaseOrderDetailModel model);

		void Update(int purchaseOrderID,
		            PurchaseOrderDetailModel model);

		void Delete(int purchaseOrderID);

		POCOPurchaseOrderDetail Get(int purchaseOrderID);

		List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>81fbb78c824492baae7d1a07712eb6d8</Hash>
</Codenesium>*/