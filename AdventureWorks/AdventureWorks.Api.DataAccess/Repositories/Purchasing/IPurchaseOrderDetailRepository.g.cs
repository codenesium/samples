using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		POCOPurchaseOrderDetail Create(ApiPurchaseOrderDetailModel model);

		void Update(int purchaseOrderID,
		            ApiPurchaseOrderDetailModel model);

		void Delete(int purchaseOrderID);

		POCOPurchaseOrderDetail Get(int purchaseOrderID);

		List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderDetail> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>87e7f91ae7b9fe521de53f62a87bcc0f</Hash>
</Codenesium>*/