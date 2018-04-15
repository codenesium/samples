using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderHeaderRepository
	{
		int Create(PurchaseOrderHeaderModel model);

		void Update(int purchaseOrderID,
		            PurchaseOrderHeaderModel model);

		void Delete(int purchaseOrderID);

		ApiResponse GetById(int purchaseOrderID);

		POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID);

		ApiResponse GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>906c8320e90750cbbe94a28cb2132199</Hash>
</Codenesium>*/