using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPurchaseOrderHeader
	{
		Task<CreateResponse<int>> Create(
			PurchaseOrderHeaderModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            PurchaseOrderHeaderModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		ApiResponse GetById(int purchaseOrderID);

		POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID);

		ApiResponse GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bed9e32d55d675f0d9d483118ee70f40</Hash>
</Codenesium>*/