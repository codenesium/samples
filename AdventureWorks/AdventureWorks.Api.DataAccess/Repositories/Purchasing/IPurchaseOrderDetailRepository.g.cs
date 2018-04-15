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

		ApiResponse GetById(int purchaseOrderID);

		POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID);

		ApiResponse GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ece684a692794635e119952ec2e01a67</Hash>
</Codenesium>*/