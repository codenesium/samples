using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		int Create(
			int purchaseOrderDetailID,
			DateTime dueDate,
			short orderQty,
			int productID,
			decimal unitPrice,
			decimal lineTotal,
			decimal receivedQty,
			decimal rejectedQty,
			decimal stockedQty,
			DateTime modifiedDate);

		void Update(int purchaseOrderID,
		            int purchaseOrderDetailID,
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

		Response GetById(int purchaseOrderID);

		POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID);

		Response GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b18123675daafc379c98a6a8d7e4346f</Hash>
</Codenesium>*/