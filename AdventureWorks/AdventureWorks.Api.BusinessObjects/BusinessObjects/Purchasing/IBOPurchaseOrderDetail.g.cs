using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPurchaseOrderDetail
	{
		Task<CreateResponse<int>> Create(
			PurchaseOrderDetailModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            PurchaseOrderDetailModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		ApiResponse GetById(int purchaseOrderID);

		POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID);

		ApiResponse GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae953f88838f0b2e6f2ca828a17db742</Hash>
</Codenesium>*/