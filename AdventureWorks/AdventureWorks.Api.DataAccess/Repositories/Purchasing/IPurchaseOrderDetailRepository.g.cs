using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		int Create(int purchaseOrderDetailID,
		           DateTime dueDate,
		           short orderQty,
		           int productID,
		           decimal unitPrice,
		           decimal lineTotal,
		           decimal receivedQty,
		           decimal rejectedQty,
		           decimal stockedQty,
		           DateTime modifiedDate);

		void Update(int purchaseOrderID, int purchaseOrderDetailID,
		            DateTime dueDate,
		            short orderQty,
		            int productID,
		            decimal unitPrice,
		            decimal lineTotal,
		            decimal receivedQty,
		            decimal rejectedQty,
		            decimal stockedQty,
		            DateTime modifiedDate);

		void Delete(int purchaseOrderID);

		void GetById(int purchaseOrderID, Response response);

		void GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>add09b66c4a0f92d11254011281dba4a</Hash>
</Codenesium>*/